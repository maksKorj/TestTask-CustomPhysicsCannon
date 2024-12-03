using _Gameplay.Scripts.Shooting.Launcher;
using Core.Scripts.Services.StaticDataService;

namespace Core.Scripts.Services.Gameplay
{
    public class GameplayService : IGameplayService
    {
        private readonly Cannon m_Cannon;
        
        public GameplayService(GameplayObjectProvider gameplayObjectProvider, IServiceLocator serviceLocator)
        {
            m_Cannon = createCannon(gameplayObjectProvider, serviceLocator);
        }

        private Cannon createCannon(GameplayObjectProvider gameplayObjectProvider, IServiceLocator serviceLocator)
        {
            var cannonComponent = gameplayObjectProvider.ITrajectoryRenderingContext;
            var gameplayData = serviceLocator.GetSingle<IGameStaticDataService>().GamePlay;
            
            return new Cannon(cannonComponent, 
                gameplayData.PhysicsConfiguration.CreateTrajectoryRenderer(cannonComponent));
        }
    }
}
