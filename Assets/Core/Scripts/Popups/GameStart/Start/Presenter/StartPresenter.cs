using System;
using Core.Scripts.Popups.Base;
using Core.Scripts.Services;
using Core.Scripts.Services.StaticDataService;

namespace Core.Scripts.Popups.GameStart.Start.Presenter
{
    public class StartPresenter : Presenter<StartView>, IStartPresenter
    {
        public event Action OnPlayButtonClick;

        public StartPresenter(StartView view, IServiceLocator serviceLocator) : base(view, serviceLocator)
        {
            m_View.BindStartButtonClick(onClick);

            var popupData = serviceLocator.GetSingle<IGameStaticDataService>().PopupData;
        }

        #region Callbacks
        private void onClick()
        {
            Close();
            OnPlayButtonClick?.Invoke();
        }
        #endregion

        public void Setup(int currentLevel)
        {
            //
        }
    }
}
