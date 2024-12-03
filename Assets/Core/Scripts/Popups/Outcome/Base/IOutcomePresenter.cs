using System;

namespace Core.Scripts.Popups.Outcome.Base
{
    public interface IOutcomePresenter
    {
        public event Action OnCompleted;
    }
}