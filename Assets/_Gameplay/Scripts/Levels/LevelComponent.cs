using Core.Scripts.Services;
using Core.Scripts.Services.Level.Level;

namespace Gameplay.Levels
{
    public class LevelComponent : LevelComponentBase
    {
        public override LevelBase CreateLevel(IServiceLocator serviceLocator)
        {
            return new Level(this, serviceLocator);
        }
    }
}
