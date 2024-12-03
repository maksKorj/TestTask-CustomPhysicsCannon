using Core.Scripts.Services.StaticDataService.Data.Input;
using UnityEngine;

namespace Core.Scripts.Services.Input.Modules.Joystick
{
    public class JoystickModule : IJoystick
    {
        private readonly bool m_IsUseJoystick;
        private readonly float m_FinalDPI;
        private readonly JoystickData m_JoystickData;

        private JoystickUI m_JoystickUI;

        private Vector2 m_JoystickDirection = Vector2.zero;
        private Vector2 m_JoystickPosition = Vector2.zero;
        private Vector2 m_JoystickHandleLocalPosition = Vector2.zero;

        private Vector2 m_JoystickPositionNormalized => m_JoystickPosition / m_FinalDPI;

        private Vector2 m_JoystickPositionFromMousePosAndDirection
            => (Vector2)UnityEngine.Input.mousePosition - m_JoystickDirection * m_JoystickData.Radius * m_FinalDPI;

        public Vector2 JoystickDirection => m_JoystickDirection;

        public JoystickModule(InputDataConfig inputData, float finalDPI)
        {
            m_IsUseJoystick = inputData.IsUseJoystick;
            m_JoystickData = inputData.Joystick;

            m_FinalDPI = finalDPI;
        }

        public void AddJoystickUi(JoystickUI joystickUI) 
        {
            m_JoystickUI = joystickUI;
        }

        #region Resetting
        public void ResetVectors()
        {
            m_JoystickDirection = Vector2.zero;
            m_JoystickPosition = Vector2.zero;
            m_JoystickHandleLocalPosition = Vector2.zero;
        }

        public void ResetJoystick(Vector2 mousePosNormalized)
        {
            if (m_IsUseJoystick == false)
            {
                return;
            }

            if (m_JoystickData.IsResetDirection)
            {
                resetDirection();
            }
            else
            {
                m_JoystickPosition = m_JoystickPositionFromMousePosAndDirection;
                m_JoystickHandleLocalPosition = m_JoystickDirection;
            }

            ComputeJoystick(mousePosNormalized);
        }
        #endregion

        #region HandleUi
        public void OnInputDown()
        {
            m_JoystickUI?.OnInputDown();
        }

        public void OnInputUp()
        {
            m_JoystickUI?.OnInputUp();
        }

        public void ProcessUiJoystick()
        {
            m_JoystickUI?.Process(m_JoystickPosition, m_JoystickHandleLocalPosition);
        }
        #endregion

        public void ComputeJoystick(Vector2 mousePosNormalized)
        {
            m_JoystickDirection = (mousePosNormalized - m_JoystickPositionNormalized) / m_JoystickData.Radius;

            if (m_JoystickData.IsStatic)
            {
                if (m_JoystickDirection.magnitude > 1)
                {
                    m_JoystickDirection.Normalize();
                }
            }
            else
            {
                if (m_JoystickDirection.magnitude > 1)
                {
                    m_JoystickDirection.Normalize();
                    m_JoystickPosition = m_JoystickPositionFromMousePosAndDirection;
                }
            }

            m_JoystickHandleLocalPosition = m_JoystickDirection;
        }

        #region Specific
        private void resetDirection()
        {
            if (m_JoystickDirection != Vector2.zero)
            {
                m_JoystickDirection = m_JoystickDirection.normalized * 0.05f;
                m_JoystickPosition = m_JoystickHandleLocalPosition = UnityEngine.Input.mousePosition - (Vector3)m_JoystickDirection;
            }
            else
            {
                m_JoystickDirection = Vector3.zero;
                m_JoystickPosition = m_JoystickHandleLocalPosition = UnityEngine.Input.mousePosition;
            }
        }
        #endregion
    }
}

