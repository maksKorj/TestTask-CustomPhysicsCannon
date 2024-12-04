using Core.Scripts.Infrastructure.GameStateMachine.Base;
using Core.Scripts.Services;
using Core.Scripts.Services.Level;
using Core.Scripts.Services.Pool;
using Core.Scripts.Services.UserInterface;

namespace Core.Scripts.Infrastructure.GameStateMachine.States
{
    public class ResetState : IState
    {
        private readonly IGameStateMachine m_StateMachine;

        private readonly IUserInterfaceService m_UserInterfaceService;
        private readonly ILevelService m_LevelService;
        private readonly IPoolService m_PoolService;

        public ResetState(IGameStateMachine stateMachine, IServiceLocator serviceLocator)
        {
            m_StateMachine = stateMachine;

            m_UserInterfaceService = serviceLocator.GetSingle<IUserInterfaceService>();
            m_LevelService = serviceLocator.GetSingle<ILevelService>();
            m_PoolService = serviceLocator.GetSingle<IPoolService>();
        }

        public void Enter()
        {
            m_UserInterfaceService.TransitionCurtain.Transition(enterLoadState);
        }

        public void Exit()
        {
            m_LevelService.ResetLevel();
            m_PoolService.Reset();
        }

        private void enterLoadState()
        {
            m_StateMachine.Enter<LoadState>();
        }
    }
}