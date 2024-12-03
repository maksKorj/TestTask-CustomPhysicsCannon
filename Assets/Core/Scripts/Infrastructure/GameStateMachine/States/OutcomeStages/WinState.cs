using Core.Scripts.Infrastructure.GameStateMachine.States.OutcomeStages.Base;
using Core.Scripts.Popups.Outcome.Win;
using Core.Scripts.Services;

namespace Core.Scripts.Infrastructure.GameStateMachine.States.OutcomeStages
{
    public class WinState : OutcomeStateBase<PopupWin>
    {
        public WinState(IGameStateMachine stateMachine, IServiceLocator serviceLocator) : base(stateMachine, serviceLocator)
        {
            //
        }
    }
}