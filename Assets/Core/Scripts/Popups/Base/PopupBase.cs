using Core.Scripts.Services;
using Core.Scripts.Services.StaticDataService.Data.PopupData;
using UnityEngine;

namespace Core.Scripts.Popups.Base
{
    public abstract class PopupBase : MonoBehaviour
    {
        public abstract void Init(IFadeData fadeData, IServiceLocator serviceLocator);

        public abstract void Open();
        public abstract void Close(bool closeInstantly = false);
    }
}
