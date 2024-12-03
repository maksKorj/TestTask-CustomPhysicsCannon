using _Gameplay.Scripts.Shooting.Launcher.TrajectoryRendering;
using _Gameplay.Scripts.Shooting.Launcher.TrajectoryRendering.Custom;
using _Gameplay.Scripts.Shooting.Projectiles.Movement;
using Core.Scripts.Services.TickProcessor;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.PhysicsTypes.Custom
{
    [CreateAssetMenu(fileName = nameof(CustomPhysicsConfiguration), menuName = "Gameplay/" + nameof(CustomPhysicsConfiguration), order = 0)]
    public class CustomPhysicsConfiguration : PhysicsConfiguration
    {
        [SerializeField] private int m_TrajectorySegments = 30;
        [SerializeField] private CustomPhysicsSettings m_PhysicsSettings;
        
        public override ITrajectoryRenderer CreateTrajectoryRenderer(ITrajectoryRenderingContext context)
        {
            return new CustomPhysicsTrajectoryRenderer(m_TrajectorySegments, 
                context, 
                m_PhysicsSettings);
        }

        public override IMovementStrategy CreateMovementStrategy(Transform projectileTransform, ITickProcessorService tickProcessorService)
        {
            return new CustomPhysicsMovementStrategy(projectileTransform, 
                m_PhysicsSettings, 
                tickProcessorService);
        }
    }
}