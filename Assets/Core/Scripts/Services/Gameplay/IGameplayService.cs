using _Gameplay.Scripts.Shooting.Launcher;

namespace Core.Scripts.Services.Gameplay
{
    public interface IGameplayService : IService
    {
        public Cannon Cannon { get; }
    }
}