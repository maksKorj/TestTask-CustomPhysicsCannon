using System;
using _Gameplay.Scripts.Shooting.Projectiles.Geometry;
using _Gameplay.Scripts.Shooting.Projectiles.Movement;
using Core.Scripts.Services.Pool.Base;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles
{
    public class Projectile : PoolEntity
    {
        [SerializeField] private ProjectileConfig m_Config;
        [SerializeField, ReadOnly] private MeshFilter m_MeshFilter;
        
        private IMovementStrategy m_MovementStrategy;
        private IGeometryProcessor m_GeometryProcessor;

        private int m_BounceAmountBeforeKill;
        private Tween m_Timer;

        #region Editor
        [Button]
        private void setRefs()
        {
            m_MeshFilter = GetComponentInChildren<MeshFilter>();
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
        
        #region Init
        public void Init(IMovementStrategy movementStrategy)
        {
            m_MovementStrategy = movementStrategy;
            m_GeometryProcessor = m_Config.CreateGeometryProcessor(m_MeshFilter);
        }

        private void OnEnable()
        {
            m_Timer = DOVirtual.DelayedCall(m_Config.KillTime, explode);
            m_MovementStrategy.OnCollided += onOnCollided;
        }

        private void OnDisable()
        {
            m_Timer?.Kill();
            m_MovementStrategy.OnCollided -= onOnCollided;
            
            m_MovementStrategy.Stop();
        }
        #endregion

        #region Callbacks
        private void explode()
        {
            takeBack();
        }
        
        private void onOnCollided()
        {
            m_BounceAmountBeforeKill--;
            if(m_BounceAmountBeforeKill < 0)
                explode();
        }
        #endregion

        public void Launch(Vector3 velocity)
        {
            m_BounceAmountBeforeKill = m_Config.BounceAmountBeforeKill;
            
            gameObject.SetActive(true);
            m_MovementStrategy.Launch(velocity);
        }

        private void Update()
        {
            m_GeometryProcessor.Process();
        }
    }
}
