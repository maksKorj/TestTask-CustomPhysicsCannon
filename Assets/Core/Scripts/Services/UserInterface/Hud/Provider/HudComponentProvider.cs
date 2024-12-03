using Core.Scripts.Extensions;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Core.Scripts.Services.UserInterface.Hud.Provider
{
    public class HudComponentProvider : MonoBehaviour, IHudComponentProvider
    {
        [field: SerializeField, ReadOnly] public TextMeshProUGUI LevelDisplay { get; private set; }

        #region Editor
        [Button]
        private void setRefs()
        {
            LevelDisplay = transform.FindDeepChild<TextMeshProUGUI>("LevelDisplay");
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
    }
}
