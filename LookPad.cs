namespace VeryDisco.MobileInput
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Lookpad mobile input
    /// Author: Nhat Linh - nhatlinh.nh2511@gmail.com - Verydisco Games
    /// </summary>
    public class LookPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Vector2 touchInput;
        private Vector2 prevDelta, dragInput;
        private bool isPressed;

        void Update()
        {
            touchInput = (dragInput - prevDelta) / Time.smoothDeltaTime;
            prevDelta = dragInput;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
            prevDelta = dragInput = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            dragInput = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            touchInput = Vector2.zero;
            isPressed = false;
        }

        public Vector2 LookDir => touchInput * Time.deltaTime;
        public bool IsPressed => isPressed;
    }
}
