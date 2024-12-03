using Core.Scripts.Popups.Base;
using Core.Scripts.Popups.Outcome.Base;
using Core.Scripts.Services;

namespace Core.Scripts.Popups.Outcome.Win
{
    public class PopupWin : Popup<OutcomeView>, IOutcomePresenterProvider
    {
        public IOutcomePresenter Presenter { get; private set; }

        protected override Presenter<OutcomeView> getPresenter(IServiceLocator serviceLocator)
        {
            var presenter = new WinPresenter(m_View, serviceLocator);
            Presenter = presenter;
            
            return presenter;
        }
    }
}
