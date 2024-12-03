using _Gameplay.Scripts.Shooting.PhysicTypes;
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
        
        public override void Init(IServiceLocator serviceLocator)
        {
            m_PhysicsConfiguration = serviceLocator.GetSingle<IGameStaticDataService>().GamePlay.PhysicsConfiguration;
            m_TickProcessorService = serviceLocator.GetSingle<ITickProcessorService>();
            
            base.Init(serviceLocator);
        }

        protected override void initCreatedInstance(Projectile spawnedEntity)
        {
            var movementStrategy = m_PhysicsConfiguration.CreateMovementStrategy(spawnedEntity.transform, 
                m_TickProcessorService);
            
            spawnedEntity.Init(movementStrategy);
        }
    }
}