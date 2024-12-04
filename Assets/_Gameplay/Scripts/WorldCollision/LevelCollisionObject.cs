using _Gameplay.Scripts.Effects;
using _Gameplay.Scripts.Levels;
using Core.Scripts.Services;
using Core.Scripts.Services.Pool;
using UnityEngine;

namespace _Gameplay.Scripts.WorldCollision
{
    public abstract class LevelCollisionObject : LevelActor, ICollisionObject
    {
        [field: SerializeField] public float BounceMultiplier { get; private set; } = 1f;
        
        private GenericEffectPool m_EffectPool;
        
        public override void Init(IServiceLocator serviceLocator)
        {
            m_EffectPool = serviceLocator.GetSingle<IPoolService>().GetPool<GenericEffectPool>();
        }

        public abstract void Collide(RaycastHit hit);
        
        protected void playEffect(RaycastHit hit, GenericEffect.EntityType type)
        {
            var effect = m_EffectPool.GetPoolable();
            
            effect.transform.position = hit.point;
            effect.Play(type);
        }
        
    }
}