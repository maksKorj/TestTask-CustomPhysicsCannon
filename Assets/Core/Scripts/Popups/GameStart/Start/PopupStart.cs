using Core.Scripts.Popups.Base;
using Core.Scripts.Popups.GameStart.Start.Presenter;
using Core.Scripts.Services;

namespace Core.Scripts.Popups.GameStart.Start
{
    public class PopupStart : Popup<StartView>
    {
        public IStartPresenter Presenter { get; private set; }

        protected override Presenter<StartView> getPresenter(IServiceLocator serviceLocator)
        {
            var presenter = new StartPresenter(m_View, serviceLocator);
            Presenter = presenter;
            
            return presenter;
        }
    }
}
