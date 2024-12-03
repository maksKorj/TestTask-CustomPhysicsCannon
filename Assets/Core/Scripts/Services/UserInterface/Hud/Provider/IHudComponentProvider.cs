using TMPro;

namespace Core.Scripts.Services.UserInterface.Hud.Provider
{
    public interface IHudComponentProvider
    {
        public TextMeshProUGUI LevelDisplay { get; }
    }
}