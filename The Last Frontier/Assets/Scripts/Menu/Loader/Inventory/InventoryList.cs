using System.Collections.Generic;
using Menu.Loader.Inventory;
using TLFGameLogic.Model;
using TLFGameLogic.Model.CannonData.Barrel;
using TLFUILogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu.Loader
{
    public class InventoryList : MonoBehaviour
    {
        public Transform contentPanel;
        [Inject] private FileSaveSystem _file;
        [Inject] private ItemPicturesResolver _resolver;
        private PlayerData _player;
        public TextMeshProUGUI _inventoryName;
        public TextMeshProUGUI _inventoryText;

        private List<GameObject> _addedButtons;

        void OnEnable()
        {
            bool someChanges = false;

            //_player =  _file.getInfo();
            _player = PlayerData.Instance;
            if (_player.BaseCannonFragments.Count == 0)
            {
                _player.BaseCannonFragments.Add(new CannonBase());
                someChanges = true;
            }

            if (_player.Barrels.Count == 0)
            {
                _player.Barrels.Add(new Barrel());
            }
            //_file.saveInfo(_player);

            _addedButtons = new List<GameObject>();
            RefreshDisplay();
        }

        public void RefreshDisplay()
        {
            RemoveButtons();
            AddButtons();
        }

        private void RemoveButtons()
        {
            foreach (var button in _addedButtons)
            {
                Destroy(button);
            }

            _addedButtons.Clear();
        }

        private void AddButtons()
        {
            Debug.Log("Refreshig");
            Debug.Log(_player.BaseCannonFragments.Count + " + " + _player.Barrels.Count);

            GameObject butt = Resources.Load<GameObject>("Prefabs/Menu/Inventory/Item_Button");
            Debug.Log(_player.BaseCannonFragments.Count);
            for (int i = 0; i < _player.BaseCannonFragments.Count; i++)
            {
                GameObject button = Instantiate(butt, contentPanel, false);
                ItemButton sampleButton = button.GetComponent<ItemButton>();
                sampleButton.SetUp(_player.BaseCannonFragments[i], null, _inventoryName, _inventoryText, _resolver);
                sampleButton.SetPicture();
                _addedButtons.Add(button);
            }

            for (int i = 0; i < _player.Barrels.Count; i++)
            {
                Debug.Log(_player.Barrels[i].DamageMultiplier);
                GameObject button = Instantiate(butt, contentPanel, false);
                ItemButton sampleButton = button.GetComponent<ItemButton>();
                sampleButton.SetUp(null, _player.Barrels[i], _inventoryName, _inventoryText, _resolver);
                sampleButton.SetPicture();
                _addedButtons.Add(button);
            }
        }
    }
}