using System.Collections.Generic;
using Core.Scripts.Popups.Base;

namespace Core.Scripts.Services.UserInterface.Popup.Provider
{
    public interface IPopupComponentProvider
    {
        public IEnumerable<PopupBase> Popups { get; }
    }
}