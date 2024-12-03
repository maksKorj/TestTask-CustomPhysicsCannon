using Core.Scripts.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Services.Input.Modules.Joystick.Provider
{
    public class JoystickComponentProvider : MonoBehaviour, IJoystickComponentProvider
    {
        [field: SerializeField, ReadOnly] public Image JoystickOutline { get; private set; }
        [field: SerializeField, ReadOnly] public Image JoystickHandle { get; private set; }

        public GameObject GameObject => gameObject;

        #region Editor
        [Button]
        private void setRefs()
        {
            JoystickOutline = transform.FindDeepChild<Image>("Outline");
            JoystickHandle = transform.FindDeepChild<Image>("Handle");
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion

    }
}
