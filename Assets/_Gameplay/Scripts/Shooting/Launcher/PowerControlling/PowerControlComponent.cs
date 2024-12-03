using Core.Scripts.Extensions;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Gameplay.Scripts.Shooting.Launcher.PowerControlling
{
    public class PowerControlComponent : MonoBehaviour
    {
        [field: SerializeField, ReadOnly] public TextMeshProUGUI AmountDisplay { get; private set; }
        [field: SerializeField, ReadOnly] public Slider Slider { get; private set; }

        #region Editor
        [Button]
        private void setRefs()
        {
            AmountDisplay = transform.FindDeepChild<TextMeshProUGUI>("AmountDisplay");
            Slider = transform.FindDeepChild<Slider>("Slider");
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
    }
}