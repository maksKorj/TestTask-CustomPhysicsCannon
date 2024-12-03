using Core.Scripts.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.StaticDataService.Data.PopupData
{
    public class PopupDataConfig : ScriptableObject, IFadeData
    {
        [field: Title("Timing")]
        [field: SerializeField] public float FadeInTime { get; private set; } = 0.5f;
        [field: SerializeField] public float FadeOutTime { get; private set; } = 0.3f;
    }
}