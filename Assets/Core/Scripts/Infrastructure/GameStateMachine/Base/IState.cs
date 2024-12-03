namespace Core.Scripts.Infrastructure.GameStateMachine.Base
{
    public interface IState : IExitableState
    {
        public void Enter();
    }
}