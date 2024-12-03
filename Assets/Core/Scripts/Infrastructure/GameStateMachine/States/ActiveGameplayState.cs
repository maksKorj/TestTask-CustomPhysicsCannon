using Core.Scripts.Infrastructure.GameStateMachine.Base;
using Core.Scripts.Infrastructure.GameStateMachine.States.OutcomeStages;
using Core.Scripts.Services;
using Core.Scripts.Services.Input;
using Core.Scripts.Services.Level;
using Core.Scripts.Services.Level.Level;
using Core.Scripts.Services.UserInterface;
using Core.Scripts.Services.UserInterface.Hud.Elements;

namespace Core.Scripts.Infrastructure.GameStateMachine.States
{
    public class ActiveGameplayState : IState
    {
        private readonly IGameStateMachine m_GameStateMachine;

        private readonly ILevelService m_LevelService;
        private readonly IInputService m_InputService;
        private readonly LevelDisplay m_LevelDisplay;

        private LevelBase m_CurrentLevel;

        public ActiveGameplayState(IGameStateMachine gameStateMachine, IServiceLocator serviceLocator)
        {
            m_GameStateMachine = gameStateMachine;

            m_LevelService = serviceLocator.GetSingle<ILevelService>();
            m_InputService = serviceLocator.GetSingle<IInputService>();

            var uiService = serviceLocator.GetSingle<IUserInterfaceService>();
            m_LevelDisplay = uiService.HudService.GetElement<LevelDisplay>();
        }

        public void Enter()
        {
            m_InputService.SetActive(true);

            m_CurrentLevel = m_LevelService.ActiveLevelEntity;
            m_CurrentLevel.OnStart();

            onActive();
        }
        
        public void Exit()
        {
            m_InputService.SetActive(false);
            m_LevelDisplay.SetActive(false);

            m_CurrentLevel.OnGameplayEnded -= onGameplayEnded;
            m_CurrentLevel.OnCompleted -= onLevelCompleted;
            m_CurrentLevel.OnFailed -= onLevelFailed;
        }

        #region Callbacks
        private void onGameplayEnded()
        {
            m_InputService.SetActive(false);
        }

        private void onLevelCompleted()
        {
            m_GameStateMachine.Enter<WinState>();
        }

        private void onLevelFailed()
        {
            m_GameStateMachine.Enter<FailState>();
        }
        #endregion

        private void onActive()
        {
            m_LevelDisplay.SetActive(true);
            m_LevelDisplay.UpdateLevel(m_LevelService.CurrentLevel);

            m_CurrentLevel.OnGameplayEnded += onGameplayEnded;
            m_CurrentLevel.OnCompleted += onLevelCompleted;
            m_CurrentLevel.OnFailed += onLevelFailed;
        }
    }
}