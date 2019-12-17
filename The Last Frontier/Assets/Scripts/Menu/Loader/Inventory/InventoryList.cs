using UnityEngine;

namespace Menu.Loader
{
    public class InventoryList:MonoBehaviour
    {
        
        void Start () 
        {
            RefreshDisplay ();
        }

        void RefreshDisplay()
        {
            RemoveButtons ();
            AddButtons ();
        }

        private void RemoveButtons()
        {
//            while (contentPanel.childCount > 0) 
//            {
//                GameObject toRemove = transform.GetChild(0).gameObject;
//                buttonObjectPool.ReturnObject(toRemove);
//            }
        }

        private void AddButtons()
        {
//            for (int i = 0; i < itemList.Count; i++) 
//            {
//                Item item = itemList[i];
//                GameObject newButton = buttonObjectPool.GetObject();
//                newButton.transform.SetParent(contentPanel);
//
//                SampleButton sampleButton = newButton.GetComponent<SampleButton>();
//                sampleButton.Setup(item, this);
//            }
        }
    }
}