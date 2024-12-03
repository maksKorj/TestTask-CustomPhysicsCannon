using Core.Scripts.Services.Level.Level;
using Core.Scripts.Services.Level.Provider;

namespace Core.Scripts.Services.Level
{
    public class LevelService : ILevelService
    {
        private readonly LevelBase[] m_Levels;

        private LevelBase m_CurrentLevel;

        public int CurrentLevel => 1;
        public LevelBase ActiveLevelEntity => m_CurrentLevel;

        public LevelService(ILevelProvider levelProvider, IServiceLocator serviceLocator)
        {
            m_Levels = new LevelBase[levelProvider.Amount];
            int index = 0;
            foreach(var levelCmponent in levelProvider.Levels) 
            {
                m_Levels[index] = levelCmponent.CreateLevel(serviceLocator);
                index++;
            }
        }

        public void ResetLevel()
        {
            if (m_CurrentLevel != null)
                m_CurrentLevel.SetActive(false);
        }

        public LevelBase ShowLevel()
        {
            return showLevel(0);
        }

        private LevelBase showLevel(int level)
        {
            ResetLevel();

            m_CurrentLevel = m_Levels[(level - 1) % m_Levels.Length];
            m_CurrentLevel.SetActive(true);

            return m_CurrentLevel;
        }
    }
}
