using _Gameplay.Scripts.Shooting.Launcher.TrajectoryRendering;
using _Gameplay.Scripts.Shooting.Projectiles.Movement;
using Core.Scripts.Services.TickProcessor;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.PhysicTypes
{
    public abstract class PhysicsConfiguration : ScriptableObject
    {
        public abstract ITrajectoryRenderer CreateTrajectoryRenderer(ITrajectoryRenderingContext context);
        public abstract IMovementStrategy CreateMovementStrategy(Transform projectileTransform, ITickProcessorService tickProcessorService);
    }
}