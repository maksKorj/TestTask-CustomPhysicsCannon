using System;

namespace Core.Scripts.Services.UserInterface.TransitionCurtain
{
    public interface ITransitionCurtain
    {
        public void Transition(Action onBecomeBlack);
    }
}