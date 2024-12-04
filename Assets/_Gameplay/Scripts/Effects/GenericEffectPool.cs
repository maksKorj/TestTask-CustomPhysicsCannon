using Core.Scripts.Services;
using Core.Scripts.Services.Pool;
using UnityEngine;

namespace _Gameplay.Scripts.Effects
{
    public class GenericEffectPool : Pool<GenericEffectHolder>
    {
        private IServiceLocator m_ServiceLocator;

        public override void Init(IServiceLocator serviceLocator)
        {
            base.Init(serviceLocator);
            m_ServiceLocator = serviceLocator;
        }

        public GenericEffectHolder PlayEffect(GenericEffect.EntityType entityType, Vector3 position, Vector3? scale = null)
        {
            var effect = GetPoolable();
            effect.transform.position = position;
            effect.transform.localScale = scale ?? Vector3.one;
            effect.Play(entityType);

            return effect;
        }

        protected override void initCreatedInstance(GenericEffectHolder spawnedEntity)
        {
            //
        }
    }
}
