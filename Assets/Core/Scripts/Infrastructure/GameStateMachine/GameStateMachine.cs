using System;
using System.Collections.Generic;
using Core.Scripts.Infrastructure.GameStateMachine.Base;
using Core.Scripts.Infrastructure.GameStateMachine.States;
using Core.Scripts.Services;
using Core.Scripts.Utilities;
using UnityEngine;

namespace Core.Scripts.Infrastructure.GameStateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly EntityProvider<IExitableState> m_StateProvider;
        
        private IExitableState m_ActiveState;
        
        public GameStateMachine(IServiceLocator serviceLocator)
        {
            var states = new Dictionary<Type, IExitableState>
            {
                [typeof(ResetState)] = new ResetState(this, serviceLocator),
                [typeof(LoadState)] = new LoadState(this, serviceLocator),
                [typeof(ActiveGameplayState)] = new ActiveGameplayState(this, serviceLocator)
            };

            m_StateProvider = new EntityProvider<IExitableState>(states);
        }

        public void Enter<TState>() where TState : class, IState
        {
            var state = сhangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TArgument>(TArgument argument) where TState: class, IParameterizedState<TArgument>
        {
            var state = сhangeState<TState>();
            state.Enter(argument);
        }

        private TState сhangeState<TState>() where TState : class, IExitableState
        {
            m_ActiveState?.Exit();

            var state = getState<TState>();
            m_ActiveState = state;

            return state;
        }

        private TState getState<TState>() where TState : class, IExitableState
        {
            if (m_StateProvider.TryGetEntity(out TState state))
                return state;

            Debug.LogError($"State of type {typeof(TState)} doesnt' exist!");
            return null;
        }
    }
}