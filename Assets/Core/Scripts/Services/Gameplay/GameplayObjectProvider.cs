using _Gameplay.Scripts.Shooting.Launcher;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.Gameplay
{
    public class GameplayObjectProvider : MonoBehaviour
    {
        [field: SerializeField, ReadOnly] public CannonComponent ITrajectoryRenderingContext { get; private set; }
        
        #region Editor
        [Button]
        private void setRefs()
        {
            ITrajectoryRenderingContext = GetComponentInChildren<CannonComponent>();
        }

        private void OnValidate()
        {
            setRefs();
        }

        #endregion
    }
}
