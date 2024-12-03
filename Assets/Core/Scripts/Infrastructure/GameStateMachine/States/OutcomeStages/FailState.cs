using Core.Scripts.Infrastructure.GameStateMachine.States.OutcomeStages.Base;
using Core.Scripts.Popups.Outcome.Fail;
using Core.Scripts.Services;

namespace Core.Scripts.Infrastructure.GameStateMachine.States.OutcomeStages
{
    public class FailState : OutcomeStateBase<PopupFail>
    {
        public FailState(IGameStateMachine stateMachine, IServiceLocator serviceLocator) : base(stateMachine, serviceLocator)
        {
            //
        }
    }
}