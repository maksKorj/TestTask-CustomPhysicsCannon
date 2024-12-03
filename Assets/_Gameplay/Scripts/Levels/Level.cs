using Core.Scripts.Services;
using Core.Scripts.Services.Level.Level;

namespace Gameplay.Levels
{
    public class Level : LevelWithComponent<LevelComponent>
    {
        public Level(LevelComponent levelComponent, IServiceLocator serviceLocator) 
            : base(levelComponent, serviceLocator)
        {

        }

        public override void OnLoad()
        {
            //
        }

        public override void OnStart()
        {
            //
        }

        public override void OnContinue()
        {
            //
        }

        protected override void onReset()
        {
            //
        }
    }
}
