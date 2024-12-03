using Core.Scripts.Services.Input.Base;
using Core.Scripts.Services.Input.Modules.Interaction;
using Core.Scripts.Services.Input.Modules.Joystick;
using Core.Scripts.Services.Input.Modules.MultiTouch;
using Core.Scripts.Services.Input.Modules.SimpleInput;
using Core.Scripts.Services.Resettable;
using Core.Scripts.Services.TickProcessor;
using UnityEngine;

namespace Core.Scripts.Services.Input
{
    public class InputService : IInputService, IUpdateTickable, IFixedUpdateTickable, IResettable
    {
        private readonly InputListener m_InputListener;
        private readonly BaseInputModule m_SimpleInputModule;

        private JoystickModule m_JoystickModule;
        private MultiTouchModule m_MultiTouchModule;
        private InteractionInputModule m_InteractionInputModule;

        private bool m_IsActive;

        public IBaseInput BaseInput => m_SimpleInputModule;

        #region Init
        public InputService(Vector2 dragSensitivity, float finalDPI, InputListener inputListener)
        {
            m_InputListener = inputListener;

            m_SimpleInputModule = new BaseInputModule(finalDPI, dragSensitivity);

            subscribe();
        }

        public void AddModule(JoystickModule joystickModule)
        {
            m_JoystickModule = joystickModule;
        }

        public void AddModule(MultiTouchModule multiTouchModule)
        {
            m_MultiTouchModule = multiTouchModule;
            m_MultiTouchModule.ResetTouchLists();
        }

        public void AddModule(InteractionInputModule interactionInputModule)
        {
            m_InteractionInputModule = interactionInputModule;
        }

        public void Reset()
        {
            m_InputListener.OnInputDown -= onPointerDown;
            m_InputListener.OnInputUp -= onPointerUp;
        }

        public void ResetControl() //onGameStarted
        {
            m_JoystickModule?.ResetVectors();
            resetValues();
        }
        #endregion

        public void SetActive(bool value)
        {
            if (value == false)
                onPointerUp(Vector2.zero);

            m_IsActive = value;
        }

        public bool TryGetJoystick(out IJoystick joystick)
        {
            joystick = m_JoystickModule;
            return joystick != null;
        }

        public bool TryGetMultiTouch(out IMultiTouch multiTouch)
        {
            multiTouch = m_MultiTouchModule;
            return multiTouch != null;
        }

        #region Callbacks
        private void onPointerDown(Vector2 position)
        {
            if (m_IsActive == false)
                return;

            resetValues();
            m_JoystickModule?.ResetJoystick(m_SimpleInputModule.MousePosNormalized);

            m_SimpleInputModule.OnPointerDown(position);

            m_JoystickModule?.OnInputDown();
            m_InteractionInputModule?.OnInputDown(position);
        }

        public void onPointerUp(Vector2 position)
        {
            if (m_IsActive == false)
                return;

            resetValues();
            m_JoystickModule?.ResetJoystick(m_SimpleInputModule.MousePosNormalized);

            m_SimpleInputModule.OnPointerUp(position);
            m_JoystickModule?.OnInputUp();
            m_InteractionInputModule?.OnInputUp(position);
        }
        #endregion

        #region UnityLoops
        public void UpdateTick()
        {
            m_MultiTouchModule?.CalculateMultiTouch(m_SimpleInputModule.MousePosNormalized);
            m_JoystickModule?.ProcessUiJoystick();
            m_InteractionInputModule?.Process();
        }

        public void FixedUpdateTick()
        {
            m_SimpleInputModule.Process();

            m_JoystickModule?.ComputeJoystick(m_SimpleInputModule.MousePosNormalized);
        }
        #endregion

        #region Specific
        private void subscribe()
        {
            m_InputListener.OnInputDown += onPointerDown;
            m_InputListener.OnInputUp += onPointerUp;
        }

        private void resetValues()
        {
            m_SimpleInputModule.Reset();
            m_MultiTouchModule?.Clear();
        }
        #endregion
    }
}

