using _Gameplay.Scripts.Shooting.Launcher.PowerControlling;
using Core.Scripts.Extensions;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Core.Scripts.Services.UserInterface.Hud.Provider
{
    public class HudComponentProvider : MonoBehaviour, IHudComponentProvider
    {
        [field: SerializeField, ReadOnly] public PowerControlComponent PowerControlComponent{ get; private set; }

        #region Editor
        [Button]
        private void setRefs()
        {
            PowerControlComponent = transform.GetComponentInChildren<PowerControlComponent>(true);
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
    }
}
