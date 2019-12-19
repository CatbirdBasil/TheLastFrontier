using UnityEngine;
using UnityEngine.EventSystems;

namespace Menu.Loader.Inventory
{
    public class ItemDragHendler : MonoBehaviour,IDragHandler,IEndDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.localPosition = Vector3.back;
        }
    }
}
