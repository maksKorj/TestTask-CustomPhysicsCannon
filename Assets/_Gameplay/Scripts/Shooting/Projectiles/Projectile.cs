using _Gameplay.Scripts.Shooting.Projectiles.Movement;
using Core.Scripts.Services.Pool.Base;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles
{
    public class Projectile : PoolEntity
    {
        private IMovementStrategy m_MovementStrategy;
        
        public void Init(IMovementStrategy movementStrategy)
        {
            m_MovementStrategy = movementStrategy;
        }

        public void Launch(Vector3 velocity)
        {
            gameObject.SetActive(true);
            m_MovementStrategy.Launch(velocity);
        }
    }
}
