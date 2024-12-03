using Core.Scripts.Services;
using Core.Scripts.Services.StaticDataService.Data.PopupData;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Popups.Base
{
    public abstract class Popup<T> : PopupBase where T : View
    {
        [SerializeField, ReadOnly] protected T m_View;

        protected Presenter<T> m_Presenter;

        #region Editor
        [Button]
        private void setRefs()
        {
            m_View = GetComponent<T>(); 
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion

        public sealed override void Init(IFadeData fadeData, IServiceLocator serviceLocator)
        {
            m_View.Init(fadeData);
            m_Presenter = getPresenter(serviceLocator);
        }

        public sealed override void Open()
        {
            m_Presenter.Open();
        }

        public sealed override void Close(bool closeInstantly = false)
        {
            m_Presenter.Close(closeInstantly);
        }

        protected abstract Presenter<T> getPresenter(IServiceLocator serviceLocator);
    }
}