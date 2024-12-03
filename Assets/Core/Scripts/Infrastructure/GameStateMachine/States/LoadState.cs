using Core.Scripts.Infrastructure.GameStateMachine.Base;
using Core.Scripts.Popups.GameStart.Start;
using Core.Scripts.Services;
using Core.Scripts.Services.Level;
using Core.Scripts.Services.UserInterface;

namespace Core.Scripts.Infrastructure.GameStateMachine.States
{
    public class LoadState : IState
    {
        private readonly IGameStateMachine m_StateMachine;
        
        private readonly ILevelService m_LevelService;
        private readonly IUserInterfaceService m_UserInterfaceService;

        public LoadState(IGameStateMachine stateMachine, IServiceLocator serviceLocator)
        {
            m_StateMachine = stateMachine;

            m_LevelService = serviceLocator.GetSingle<ILevelService>();
            m_UserInterfaceService = serviceLocator.GetSingle<IUserInterfaceService>();
        }

        public void Enter()
        {
            var activeLevel = m_LevelService.ShowLevel();
            activeLevel.OnLoad();

            m_UserInterfaceService.PopupService.OpenWithAction<PopupStart>(init);
        }

        public void Exit()
        {
            //
        }

        private void init(PopupStart popup) 
        {
            popup.Presenter.Setup(m_LevelService.CurrentLevel);

            m_StateMachine.Enter<IdleState, PopupStart>(popup);
        }
    }
}