using System;
using Core.Scripts.Popups.Base;

namespace Core.Scripts.Services.UserInterface.Popup
{
    public interface IPopupService
    {
        public void Open<T>() where T : PopupBase;
        public void OpenWithAction<T>(Action<T> action) where T : PopupBase;
        
        public T Peek<T>() where T : PopupBase;

        public void Close<T>(bool instantly = false) where T : PopupBase;
        public void CloseOpened(bool instantly = true);
    }
}