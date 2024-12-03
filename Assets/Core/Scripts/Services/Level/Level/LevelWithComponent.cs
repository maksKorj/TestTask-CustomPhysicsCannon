namespace Core.Scripts.Services.Level.Level
{
    public abstract class LevelWithComponent<T> : LevelBase where T : LevelComponentBase
    {
        protected readonly T m_LevelComponent;

        public LevelWithComponent(T levelComponent, IServiceLocator serviceLocator) 
            : base(serviceLocator)
        {
            m_LevelComponent = levelComponent;
        }

        public sealed override void SetActive(bool value)
        {
            if (value == false)
                onReset();

            m_LevelComponent.SetActive(value);
        }

        protected abstract void onReset();
    }
}
