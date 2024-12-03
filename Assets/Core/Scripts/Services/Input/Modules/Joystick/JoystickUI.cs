using Core.Scripts.Services.Input.Base.Data;
using Core.Scripts.Services.Input.Modules.Joystick.Provider;
using Core.Scripts.Services.StaticDataService.Data.Input;
using Core.Scripts.Services.UserInterface.Canvas;
using UnityEngine;

namespace Core.Scripts.Services.Input.Modules.Joystick
{
    public class JoystickUI
    {
        private readonly IJoystickComponentProvider m_ComponentProvider;
        private readonly ICanvasProvider m_CanvasProvider;
        private readonly ScreenData m_ScreenData;
        private readonly JoystickData m_JoystickData;

        private float m_CurrentMatchWidthOrHeight;

        private GameObject m_GameObject => m_ComponentProvider.GameObject;

        #region Init
        public JoystickUI(IJoystickComponentProvider componentProvider, 
            ICanvasProvider canvasProvider, 
            ScreenData screenData, 
            JoystickData joystickData)
        {
            m_ComponentProvider = componentProvider;
            m_CanvasProvider = canvasProvider;

            m_ScreenData = screenData;
            m_JoystickData = joystickData;

            show();

            m_CurrentMatchWidthOrHeight = m_CanvasProvider.Scaler.matchWidthOrHeight;
            setSizes();
        }

        private void show()
        {
            m_GameObject.SetActive(true);
            m_ComponentProvider.JoystickOutline.gameObject.SetActive(false);
        }
        #endregion

        #region Callbacks
        public void OnInputDown()
        {
            m_ComponentProvider.JoystickOutline.gameObject.SetActive(true);
        }

        public void OnInputUp()
        {
            m_ComponentProvider.JoystickOutline.gameObject.SetActive(false);
        }
        #endregion

        public void Process(Vector2 joystickPosition, Vector2 joystickHandleLocalPosition)
        {
            if (m_GameObject.activeInHierarchy == false)
                return;

            if (m_CurrentMatchWidthOrHeight != m_CanvasProvider.Scaler.matchWidthOrHeight)
            {
                m_CurrentMatchWidthOrHeight = m_CanvasProvider.Scaler.matchWidthOrHeight;
                setSizes();
            }

            var screenSize = Mathf.Lerp(m_ScreenData.ScreenSizeInch.x, m_ScreenData.ScreenSizeInch.y, m_CanvasProvider.Scaler.matchWidthOrHeight);
            m_ComponentProvider.JoystickOutline.rectTransform.localScale = Vector3.one / screenSize * m_JoystickData.Radius * 2;
            m_ComponentProvider.JoystickOutline.rectTransform.anchoredPosition = joystickPosition / m_CanvasProvider.Canvas.scaleFactor;
            m_ComponentProvider.JoystickHandle.rectTransform.anchoredPosition = getHandlerPosition(joystickHandleLocalPosition);
        }

        private void setSizes()
        {
            m_ComponentProvider.JoystickOutline.rectTransform.sizeDelta = getJoystickOutlineSize();
            m_ComponentProvider.JoystickHandle.rectTransform.sizeDelta = m_ComponentProvider.JoystickOutline.rectTransform.sizeDelta * m_JoystickData.HandleRadiusMultiplier;
        }

        private Vector2 getJoystickOutlineSize()
        {
            return Vector2.one * Mathf.Lerp(m_CanvasProvider.Scaler.referenceResolution.x, 
                m_CanvasProvider.Scaler.referenceResolution.y, 
                m_CanvasProvider.Scaler.matchWidthOrHeight);
        }

        private Vector2 getHandlerPosition(Vector2 joystickHandleLocalPosition)
        {
            return joystickHandleLocalPosition * m_ComponentProvider.JoystickOutline.rectTransform.sizeDelta.y * .5f;
        }
    }
}
