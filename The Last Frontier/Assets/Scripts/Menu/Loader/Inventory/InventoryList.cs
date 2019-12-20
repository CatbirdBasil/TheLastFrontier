using TLFGameLogic.Model;
using TLFGameLogic.Model.CannonData.Barrel;
using TLFUILogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu.Loader
{
    public class InventoryList:MonoBehaviour
    {
        public Transform contentPanel;
        [Inject] private FileSaveSystem _file;
        private PlayerData _player;
        public TextMeshProUGUI _inventoryName;
        public TextMeshProUGUI _inventoryText;
        
        void Start ()
        {
            bool someChanges = false;
            _player =  _file.getInfo();
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
           
            RefreshDisplay ();
        }

        void RefreshDisplay()
        {
            RemoveButtons ();
            AddButtons ();
        }

        private void RemoveButtons()
        {
            
        }

        private void AddButtons()
        {
            GameObject butt = Resources.Load<GameObject>("Prefabs/Menu/Inventory/Item_Button");
            Debug.Log(_player.BaseCannonFragments.Count);
            for (int i = 0; i < _player.BaseCannonFragments.Count; i++)
            {
                GameObject button = Instantiate(butt, contentPanel, false); 
                ItemButton sampleButton =button.GetComponent<ItemButton>();
                sampleButton.SetUp(_player.BaseCannonFragments[i], null,_inventoryName,_inventoryText);
                sampleButton.SetPicture();
            }
            for (int i = 0; i < _player.Barrels.Count; i++)
            {
                GameObject button = Instantiate(butt, contentPanel, false); 
                ItemButton sampleButton =button.GetComponent<ItemButton>();
                sampleButton.SetUp(null, _player.Barrels[i],_inventoryName,_inventoryText);
                sampleButton.SetPicture();
            }
        }
    }
}