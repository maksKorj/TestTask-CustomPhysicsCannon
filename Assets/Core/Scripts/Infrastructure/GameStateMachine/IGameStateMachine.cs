using Core.Scripts.Infrastructure.GameStateMachine.Base;

namespace Core.Scripts.Infrastructure.GameStateMachine
{
    public interface IGameStateMachine
    {
        public void Enter<TState>() where TState : class, IState;
        public void Enter<TState, TArgument>(TArgument argument) where TState : class, IParameterizedState<TArgument>;
    }
}