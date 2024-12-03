using _Gameplay.Scripts.Shooting.Projectiles.Movement;
using Core.Scripts.Services.Pool.Base;
using DG.Tweening;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles
{
    public class Projectile : PoolEntity
    {
        [SerializeField] private ProjectileConfig m_Config;
        
        private IMovementStrategy m_MovementStrategy;
        
        private Tween m_Timer;

        #region Init
        public void Init(IMovementStrategy movementStrategy)
        {
            m_MovementStrategy = movementStrategy;
        }

        private void OnEnable()
        {
            m_Timer = DOVirtual.DelayedCall(m_Config.KillTime, explode);
        }

        private void OnDisable()
        {
            m_Timer?.Kill();
        }
        #endregion

        #region Callbacks
        private void explode()
        {
            takeBack();
        }
        #endregion

        public void Launch(Vector3 velocity)
        {
            gameObject.SetActive(true);
            m_MovementStrategy.Launch(velocity);
        }
    }
}
