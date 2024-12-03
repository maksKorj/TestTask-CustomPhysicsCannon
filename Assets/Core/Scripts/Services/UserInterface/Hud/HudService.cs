using System;
using System.Collections.Generic;
using _Gameplay.Scripts.Shooting.Launcher.PowerControlling;
using Core.Scripts.Services.UserInterface.Hud.Elements;
using Core.Scripts.Services.UserInterface.Hud.Elements.Base;
using Core.Scripts.Services.UserInterface.Hud.Provider;
using Core.Scripts.Utilities;

namespace Core.Scripts.Services.UserInterface.Hud
{
    public class HudService : IHudService
    {
        private readonly EntityProvider<IHudElement> m_HudElementProvider;

        public HudService(IHudComponentProvider hudProvider)
        {
            var elements = new Dictionary<Type, IHudElement>
            {
                [typeof(LevelDisplay)] = new LevelDisplay(hudProvider.LevelDisplay),
                [typeof(PowerControl)] = new PowerControl(hudProvider.PowerControlComponent)
            };

            m_HudElementProvider = new EntityProvider<IHudElement>(elements);
        }

        public T GetElement<T>() where T : IHudElement
        {
            return m_HudElementProvider.TryGetEntity(out T element) ? element : default;
        }
    }
}