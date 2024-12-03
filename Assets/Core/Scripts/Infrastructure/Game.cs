using Core.Scripts.Infrastructure.GameStateMachine;
using Core.Scripts.Infrastructure.GameStateMachine.States;
using Core.Scripts.Services;

namespace Core.Scripts.Infrastructure
{
    public class Game
    {
        private readonly GameStateMachine.GameStateMachine m_GameStateMachine;
        
        public IGameStateMachine StateMachine => m_GameStateMachine;

        public Game(IServiceLocator serviceLocator)
        {
            m_GameStateMachine = new GameStateMachine.GameStateMachine(serviceLocator);
        }

        public void Start() 
        {
            m_GameStateMachine.Enter<LoadState>();
        }
    }
}