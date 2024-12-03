using System;
using System.Collections.Generic;
using Core.Scripts.Services.UserInterface.Hud.Elements;
using Core.Scripts.Services.UserInterface.Hud.Elements.Base;
using Core.Scripts.Services.UserInterface.Hud.Provider;
using Core.Scripts.Services.UserInterface.Popup;
using Core.Scripts.Utilities;

namespace Core.Scripts.Services.UserInterface.Hud
{
    public class HudService : IHudService
    {
        private EntityProvider<IHudElement> m_HudElementProvider;

        public HudService(IHudComponentProvider hudProvider, PopupService popupService)
        {
            var elements = new Dictionary<Type, IHudElement>
            {
                [typeof(LevelDisplay)] = new LevelDisplay(hudProvider.LevelDisplay)
            };

            m_HudElementProvider = new EntityProvider<IHudElement>(elements);
        }

        public T GetElement<T>() where T : IHudElement
        {
            if (m_HudElementProvider.TryGetEntity(out T element))
            {
                return element;
            }

            return default;
        }
    }
}