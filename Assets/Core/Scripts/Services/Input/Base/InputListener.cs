using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Scripts.Services.Input.Base
{
    public class InputListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action<Vector2> OnInputDown;
        public event Action<Vector2> OnInputUp;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnInputDown?.Invoke(eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnInputUp?.Invoke(eventData.position);
        }
    }
}

