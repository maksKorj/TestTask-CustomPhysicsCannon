using System;
using _Gameplay.Scripts.Shooting.PhysicsTypes.Custom;
using Core.Scripts.Services.TickProcessor;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles.Movement
{
    public class CustomPhysicsMovementStrategy : IMovementStrategy, IUpdateTickable
    {
        private readonly Transform m_Transform;
        private readonly CustomPhysicsSettings m_Settings;
        private readonly ITickProcessorService m_TickProcessorService;

        private Vector3 m_Velocity;
        
        public event Action OnCollided;

        public CustomPhysicsMovementStrategy(Transform transform, CustomPhysicsSettings settings, ITickProcessorService tickProcessorService)
        {
            m_Transform = transform;
            m_Settings = settings;
            m_TickProcessorService = tickProcessorService;
        }


        public void Launch(Vector3 velocity)
        {
            m_Velocity = velocity;
            m_TickProcessorService.Add(this);
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
                
                if (Physics.Linecast(m_Transform.position, nextPosition, out var hit, m_Settings.CollisionMask))
                {
                    handleCollision(hit);
                }
                else
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
            m_Transform.position = hit.point + hit.normal * 0.01f;
            
            OnCollided?.Invoke();
        }
    }
}