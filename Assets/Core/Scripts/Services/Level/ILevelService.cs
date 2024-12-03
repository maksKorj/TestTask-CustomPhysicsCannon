using Core.Scripts.Services.Level.Level;

namespace Core.Scripts.Services.Level
{
    public interface ILevelService : IService
    {
        public int CurrentLevel { get; }
        public LevelBase ActiveLevelEntity { get; }

        public void ResetLevel();
        public LevelBase ShowLevel();
    }
}