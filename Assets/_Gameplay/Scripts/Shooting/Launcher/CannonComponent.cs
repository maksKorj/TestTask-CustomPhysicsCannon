using _Gameplay.Scripts.Shooting.Launcher.MovementControlling;
using _Gameplay.Scripts.Shooting.Launcher.MovementControlling.Data;
using _Gameplay.Scripts.Shooting.Launcher.TrajectoryRendering;
using Core.Scripts.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher
{
    public class CannonComponent : MonoBehaviour, ITrajectoryRenderingContext, IMovementControlContext
    {
        [field: SerializeField] public float ProjectileMaxPower { get; private set; } = 50f;
        [field: SerializeField] public float CameraShakeAmplitude { get; private set; } = 3f;
        [field: SerializeField] public MovementControlSettings MovementControlSettings { get; private set; }
        
        [field: Title("Components")]
        [field: SerializeField, ReadOnly] public Transform Barrel {get; private set;}
        [field: SerializeField, ReadOnly] public Transform FirePoint {get; private set;}
        [field: SerializeField, ReadOnly] public LineRenderer LineRenderer {get; private set;}
        [field: SerializeField, ReadOnly] public Transform CameraPoint {get; private set;}
        [field: SerializeField, ReadOnly] public ParticleSystem LaunchVFX {get; private set;}

        public Transform Transform => transform;

        #region Editor
        [Button]
        private void setRefs()
        {
            Barrel = transform.FindDeepChild("Barrel");
            FirePoint = transform.FindDeepChild("FirePoint");
            LineRenderer = GetComponentInChildren<LineRenderer>(true);
            CameraPoint = transform.FindDeepChild("CameraPoint");
            LaunchVFX = GetComponentInChildren<ParticleSystem>(true);
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion

        public void SetupLineRenderer()
        {
            var lineRenderer = LineRenderer.transform;
            lineRenderer.parent = transform.parent;
            lineRenderer.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
    }
}