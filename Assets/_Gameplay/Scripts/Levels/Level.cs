using Core.Scripts.Services;
using Core.Scripts.Services.Gameplay;
using Core.Scripts.Services.Level.Level;

namespace _Gameplay.Scripts.Levels
{
    public class Level : LevelWithComponent<LevelComponent>
    {
        private readonly IGameplayService m_GameplayService;
        
        public Level(LevelComponent levelComponent, IServiceLocator serviceLocator) 
            : base(levelComponent, serviceLocator)
        {
            m_GameplayService = serviceLocator.GetSingle<IGameplayService>();
        }

        public override void OnLoad()
        {
            m_GameplayService.Cannon.Place(m_LevelComponent.CannonPoint);
        }

        public override void OnStart()
        {
            m_GameplayService.Cannon.SetActive(true);
        }

        public override void OnContinue()
        {
            //
        }

        protected override void onReset()
        {
            m_GameplayService.Cannon.SetActive(false);
        }
    }
}
