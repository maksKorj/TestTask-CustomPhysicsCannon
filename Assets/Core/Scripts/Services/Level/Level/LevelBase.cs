using System;

namespace Core.Scripts.Services.Level.Level
{
    public abstract class LevelBase
    {
        protected readonly IServiceLocator m_ServiceLocator;

        public event Action OnCompleted;
        public event Action OnFailed;
        public event Action OnGameplayEnded;

        public LevelBase(IServiceLocator serviceLocator)
        {
            m_ServiceLocator = serviceLocator;
        }

        public abstract void SetActive(bool value);
        public abstract void OnLoad();
        public abstract void OnStart();
        public abstract void OnContinue();

        #region Events
        protected void invokeCompleteEvent()
        {
            OnCompleted?.Invoke();
        }

        protected void invokeFailEvent()
        {
            OnFailed?.Invoke();
        }

        protected void invokeGameplayEnded()
        {
            OnGameplayEnded?.Invoke();
        }
        #endregion
    }
}
