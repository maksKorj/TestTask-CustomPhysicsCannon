using Core.Scripts.Popups.Base;
using Core.Scripts.Popups.Outcome.Base;
using Core.Scripts.Services;

namespace Core.Scripts.Popups.Outcome.Fail
{
    public class PopupFail : Popup<OutcomeView>, IOutcomePresenterProvider
    {
        public IOutcomePresenter Presenter { get; private set; }

        protected override Presenter<OutcomeView> getPresenter(IServiceLocator serviceLocator)
        {
            var presenter = new FailPresenter(m_View, serviceLocator);
            Presenter = presenter;

            return presenter;
        }
    }
}
