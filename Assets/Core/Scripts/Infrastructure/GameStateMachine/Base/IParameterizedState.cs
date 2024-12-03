namespace Core.Scripts.Infrastructure.GameStateMachine.Base
{
    public interface IParameterizedState<T> : IExitableState
    {
        public void Enter(T arg);
    }
}
