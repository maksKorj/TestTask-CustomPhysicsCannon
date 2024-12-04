using _Gameplay.Scripts.Effects;
using _Gameplay.Scripts.Shooting.PhysicsTypes;
using Core.Scripts.Services;
using Core.Scripts.Services.Pool;
using Core.Scripts.Services.StaticDataService;
using Core.Scripts.Services.TickProcessor;

namespace _Gameplay.Scripts.Shooting.Projectiles
{
    public class ProjectilePool : Pool<Projectile>
    {
        private PhysicsConfiguration m_PhysicsConfiguration;
        private ITickProcessorService m_TickProcessorService;
        private GenericEffectPool m_EffectPool;
        
        public override void Init(IServiceLocator serviceLocator)
        {
            m_PhysicsConfiguration = serviceLocator.GetSingle<IGameStaticDataService>().GamePlay.PhysicsConfiguration;
            m_TickProcessorService = serviceLocator.GetSingle<ITickProcessorService>();
            m_EffectPool = serviceLocator.GetSingle<IPoolService>().GetPool<GenericEffectPool>();


            base.Init(serviceLocator);
        }

        protected override void initCreatedInstance(Projectile spawnedEntity)
        {
            var movementStrategy = m_PhysicsConfiguration.CreateMovementStrategy(spawnedEntity.transform, 
                m_TickProcessorService);
            
            spawnedEntity.Init(movementStrategy, m_EffectPool);
        }
    }
}