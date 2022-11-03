using UnityEngine.EventSystems;


namespace Core {

    public class Joystick : BaseJoystick 
    {
        public static Joystick joystick;

        protected override void Start() 
        {
            if (joystick == null)
                joystick = this;

            base.Start();
            background.gameObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData) 
        {
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData) 
        {
            background.gameObject.SetActive(false);
            base.OnPointerUp(eventData);
        }
    }
}