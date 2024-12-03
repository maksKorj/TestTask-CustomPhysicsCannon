using System;
using System.Collections.Generic;
using Core.Scripts.Popups.Base;
using Core.Scripts.Services.StaticDataService;
using Core.Scripts.Utilities;

namespace Core.Scripts.Services.UserInterface.Popup
{
    public class PopupService : IPopupService
    {
        private readonly EntityProvider<PopupBase> m_PopupProvider;
        private readonly List<PopupBase> m_OpenedPopups = new();

        public PopupService(IServiceLocator serviceLocator, IEnumerable<PopupBase> popups)
        {
            var data = serviceLocator.GetSingle<IGameStaticDataService>().PopupData;

            foreach(var popup in popups) 
            {
                popup.Init(data, serviceLocator);
            }

            m_PopupProvider = new EntityProvider<PopupBase>(popups);
        }

        public void Open<T>() where T : PopupBase
        {
            if (m_PopupProvider.TryGetEntity(out T popup) == false)
            {
                return;
            }

            open(popup);
        }

        public void OpenWithAction<T>(Action<T> action) where T : PopupBase
        {
            if (m_PopupProvider.TryGetEntity(out T targetPopup) == false)
            {
                return;
            }

            action(targetPopup);
            open(targetPopup);
        }

        public void Close<T>(bool instantly = false) where T : PopupBase
        {
            if (m_PopupProvider.TryGetEntity(out T popup))
                popup.Close(instantly);
        }

        public void CloseOpened(bool instantly = true)
        {
            foreach (var popup in m_OpenedPopups)
                popup.Close(instantly);
        }

        public T Peek<T>() where T : PopupBase
        {
            if (m_PopupProvider.TryGetEntity(out T popup))
            {
                return popup;
            }

            return null;
        }

        private void open(PopupBase popup)
        {
            m_OpenedPopups.Add(popup);
            popup.Open();
        }
    }
}
