using _Gameplay.Scripts.Shooting.Launcher.Controlling;
using _Gameplay.Scripts.Shooting.Launcher.Controlling.Data;
using _Gameplay.Scripts.Shooting.Launcher.TrajectoryRendering;
using Core.Scripts.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher
{
    public class CannonComponent : MonoBehaviour, ITrajectoryRenderingContext, IMovementControlContext
    {
        [field: SerializeField] public MovementControlSettings MovementControlSettings { get; private set; }
        
        [field: Title("Components")]
        [field: SerializeField, ReadOnly] public Transform Barrel {get; private set;}
        [field: SerializeField, ReadOnly] public Transform FirePoint {get; private set;}
        [field: SerializeField, ReadOnly] public LineRenderer LineRenderer {get; private set;}
        [field: SerializeField, ReadOnly] public Transform CameraPoint {get; private set;}

        public Transform Transform => transform;
        
        #region Editor
        [Button]
        private void setRefs()
        {
            Barrel = transform.FindDeepChild("Barrel");
            FirePoint = transform.FindDeepChild("FirePoint");
            LineRenderer = GetComponentInChildren<LineRenderer>(true);
            CameraPoint = transform.FindDeepChild("CameraPoint");
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
    }
}