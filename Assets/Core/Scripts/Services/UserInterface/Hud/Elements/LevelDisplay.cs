using Core.Scripts.Extensions;
using Core.Scripts.Services.UserInterface.Hud.Elements.Base;
using TMPro;

namespace Core.Scripts.Services.UserInterface.Hud.Elements
{
    public class LevelDisplay : IHudElement
    {
        private readonly TextMeshProUGUI m_LevelDisplay;

        private const string k_LevelStringFormat = "Level {0}";

        public LevelDisplay(TextMeshProUGUI levelDisplay)
        {
            m_LevelDisplay = levelDisplay;
        }

        public void UpdateLevel(int level)
        {
            m_LevelDisplay.text = k_LevelStringFormat.Formatted(level);
        }

        public void SetActive(bool value)
        {
            m_LevelDisplay.gameObject.SetActive(value);
        }
    }
}
