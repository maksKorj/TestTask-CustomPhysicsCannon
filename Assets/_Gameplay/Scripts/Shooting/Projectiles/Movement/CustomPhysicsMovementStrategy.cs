using System;
using _Gameplay.Scripts.Shooting.PhysicsTypes.Custom;
using _Gameplay.Scripts.Shooting.Projectiles.CollisionDetection;
using Core.Scripts.Services.TickProcessor;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles.Movement
{
    public class CustomPhysicsMovementStrategy : IMovementStrategy, IUpdateTickable
    {
        private readonly Transform m_Transform;
        private readonly CustomPhysicsSettings m_Settings;
        private readonly ITickProcessorService m_TickProcessorService;
        private readonly ICollisionDetector m_CollisionDetector;

        private Vector3 m_Velocity;
        
        public event Action OnCollided;

        public CustomPhysicsMovementStrategy(Transform transform, CustomPhysicsSettings settings, ITickProcessorService tickProcessorService, ICollisionDetector collisionDetector)
        {
            m_Transform = transform;
            m_Settings = settings;
            m_TickProcessorService = tickProcessorService;
            m_CollisionDetector = collisionDetector;
        }

        public void Launch(Vector3 velocity)
        {
            m_Velocity = velocity;
            m_TickProcessorService.Add(this);
        }

        public void Stop()
        {
            m_TickProcessorService.Remove(this);
        }
        
        public void UpdateTick()
        {
            simulateTrajectory(Time.deltaTime);
        }

        private void simulateTrajectory(float deltaTime)
        {
            var remainingTime = deltaTime;
            
            while (remainingTime > 0)
            {
                var step = Mathf.Min(m_Settings.TimeStep, remainingTime);
                var displacement = m_Velocity * step + m_Settings.Gravity * (0.5f * step * step);
                var nextPosition = m_Transform.position + displacement;
                
                var hasCollision = false;
                if (m_CollisionDetector.HasCollision(displacement, out var hit))
                {
                    hasCollision = true;
                    handleCollision(hit);
                }

                if (hasCollision == false)
                {
                    m_Transform.position = nextPosition;
                    m_Velocity += m_Settings.Gravity * step;
                }
                
                remainingTime -= step;
            }
        }

        private void handleCollision(RaycastHit hit)
        {
            m_Velocity = Vector3.Reflect(m_Velocity, hit.normal) * m_Settings.Bounciness;
            m_Transform.position = m_CollisionDetector.CalculateNextPosition(hit);

            OnCollided?.Invoke();
        }

        
    }
}