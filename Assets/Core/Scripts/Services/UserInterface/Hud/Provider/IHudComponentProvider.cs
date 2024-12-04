using _Gameplay.Scripts.Shooting.Launcher.PowerControlling;
using TMPro;

namespace Core.Scripts.Services.UserInterface.Hud.Provider
{
    public interface IHudComponentProvider
    {
        public PowerControlComponent PowerControlComponent { get; }
    }
}