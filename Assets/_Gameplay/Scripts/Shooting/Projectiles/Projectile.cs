using _Gameplay.Scripts.Effects;
using _Gameplay.Scripts.Shooting.Projectiles.Geometry;
using _Gameplay.Scripts.Shooting.Projectiles.Movement;
using _Gameplay.Scripts.WorldCollision;
using Core.Scripts.Services.Audio.AudioPlayers;
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
        private GenericEffectPool m_EffectPool;
        private SoundEffectPlayer m_SoundEffectPlayer;

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
        public void Init(IMovementStrategy movementStrategy, GenericEffectPool genericEffectPool, SoundEffectPlayer soundEffectPlayer)
        {
            m_MovementStrategy = movementStrategy;
            m_EffectPool =genericEffectPool;
            m_SoundEffectPlayer = soundEffectPlayer;

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
            transform.DOKill();
            
            m_MovementStrategy.OnCollided -= onOnCollided;
            m_MovementStrategy.Stop();
        }
        #endregion

        #region Callbacks
        private void explode()
        {
            playExplosionEffect();

            takeBack();
        }

        private void onOnCollided(RaycastHit hit, ICollisionObject collisionObject)
        {
            m_BounceAmountBeforeKill--;
            if(m_BounceAmountBeforeKill < 0)
                explode();
            
            collisionObject?.Collide(hit);
        }
        #endregion

        public void Launch(Vector3 velocity)
        {
            m_BounceAmountBeforeKill = m_Config.BounceAmountBeforeKill;
            m_GeometryProcessor.Reset();

            transform.localScale = Vector3.one * 0.25f;
            gameObject.SetActive(true);
            m_MovementStrategy.Launch(velocity);

            transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.Linear);
        }

        private void Update()
        {
            m_GeometryProcessor.Process();
        }
        
        private void playExplosionEffect()
        {
            var effect = m_EffectPool.GetPoolable();
            effect.transform.position = transform.position;
            effect.Play(GenericEffect.EntityType.Explosion);

            m_SoundEffectPlayer.TryPlay(m_SoundEffectPlayer.Sounds.Explosion);
        }
    }
}
