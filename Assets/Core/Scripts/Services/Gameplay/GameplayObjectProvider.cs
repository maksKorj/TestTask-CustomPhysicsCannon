using _Gameplay.Scripts.Shooting.Launcher;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.Gameplay
{
    public class GameplayObjectProvider : MonoBehaviour
    {
        [field: SerializeField, ReadOnly] public CannonComponent CannonComponent { get; private set; }
        
        #region Editor
        [Button]
        private void setRefs()
        {
            CannonComponent = GetComponentInChildren<CannonComponent>(true);
        }

        private void OnValidate()
        {
            setRefs();
        }

        #endregion
    }
}
