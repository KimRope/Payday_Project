using UnityEngine;
using UnityEngine.EventSystems;

namespace MainMenu
{
    public class UIEventTest : MonoBehaviour
    , IPointerClickHandler
    , IDragHandler
    , IPointerEnterHandler
    , IPointerExitHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Click");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Drag");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Enter");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Exit");
        }
    }
}