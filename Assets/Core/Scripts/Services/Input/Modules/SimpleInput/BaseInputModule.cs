using System;
using UnityEngine;

namespace Core.Scripts.Services.Input.Modules.SimpleInput
{
    public class BaseInputModule : IBaseInput
    {
        private readonly float m_FinalDPI;
        private readonly Vector2 m_DragSensitivity;

        private bool m_IsInputDown;
        private Vector3 m_InputDownPosNormalized;
        private Vector3 m_LastInputPosNormalized;
        private Vector2 m_DeltaDrag;
        private Vector2 m_Drag;

        public bool IsInputDown => m_IsInputDown;
        public Vector2 DeltaDrag => m_DeltaDrag;
        public Vector2 Drag => m_Drag;
        public Vector3 MousePosNormalized => UnityEngine.Input.mousePosition / m_FinalDPI;

        public event Action<Vector2> OnInputDown;
        public event Action<Vector2> OnInputUp;
        public event Action<Vector2> OnDragDelta;
        public event Action<Vector2> OnDrag;

        #region Init
        public BaseInputModule(float finalDPI, Vector2 dragSensitivity)
        {
            m_FinalDPI = finalDPI;
            m_DragSensitivity = dragSensitivity;
        }

        public void Reset()
        {
            m_DeltaDrag = m_Drag = Vector2.zero;
        }
        #endregion

        #region Callbacks
        public void OnPointerDown(Vector2 position)
        {
            m_IsInputDown = true;
            m_InputDownPosNormalized = m_LastInputPosNormalized = MousePosNormalized;

            OnInputDown?.Invoke(position);
        }

        public void OnPointerUp(Vector2 position)
        {
            m_IsInputDown = false;

            OnInputUp?.Invoke(position);
        }
        #endregion

        public void Process()
        {
            if (!m_IsInputDown) return;

            m_Drag = (MousePosNormalized - m_InputDownPosNormalized) * m_DragSensitivity;
            m_DeltaDrag = (MousePosNormalized - m_LastInputPosNormalized) * m_DragSensitivity;

            if (m_Drag != Vector2.zero)
                OnDrag?.Invoke(Drag);

            if (m_DeltaDrag != Vector2.zero)
                OnDragDelta?.Invoke(DeltaDrag);

            m_LastInputPosNormalized = MousePosNormalized;
        }
    }
}

