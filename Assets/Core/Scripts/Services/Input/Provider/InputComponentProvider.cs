using Core.Scripts.Services.Input.Base;
using Core.Scripts.Services.Input.Modules.Joystick.Provider;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.Input.Provider
{
    public class InputComponentProvider : MonoBehaviour, IInputComponentProvider
    {
        [field: SerializeField, ReadOnly] public InputListener InputListener { get; private set; }
        [field: SerializeField, ReadOnly] public JoystickComponentProvider JoystickComponentProvider { get; private set; }

        #region Editor
        [Button]
        private void setRefs()
        {
            InputListener = GetComponentInChildren<InputListener>();
            JoystickComponentProvider = GetComponentInChildren<JoystickComponentProvider>(true);
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
    }
}

