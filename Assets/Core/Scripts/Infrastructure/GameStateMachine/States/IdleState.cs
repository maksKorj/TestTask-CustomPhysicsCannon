using Core.Scripts.Infrastructure.GameStateMachine.Base;
using Core.Scripts.Popups.GameStart.Start;

namespace Core.Scripts.Infrastructure.GameStateMachine.States
{
    public class IdleState : IParameterizedState<PopupStart>
    {
        private readonly IGameStateMachine m_GameStateMachine;

        private PopupStart m_PopupStart;

        public IdleState(IGameStateMachine gameStateMachine)
        {
            m_GameStateMachine = gameStateMachine;
        }

        public void Enter(PopupStart popupStart)
        {
            m_PopupStart = popupStart;
            m_PopupStart.Presenter.OnPlayButtonClick += startGame;
        }

        public void Exit()
        {
            m_PopupStart.Presenter.OnPlayButtonClick -= startGame;
        }

        #region Callbacks
        private void startGame()
        {
            m_GameStateMachine.Enter<ActiveGameplayState>();
        }
        #endregion
    }
}