using Core.Scripts.Popups.Outcome.Base;
using Core.Scripts.Services;

namespace Core.Scripts.Popups.Outcome.Fail
{
    public class FailPresenter : OutcomePresenter
    {
        protected override string m_LevelDisplayStringFormat => "Level {0} \n FAILED";

        public FailPresenter(OutcomeView view, IServiceLocator serviceLocator) : base(view, serviceLocator)
        {

        }

        protected override int getInitialEarnings()
        {
            return 50;
        }
    }
}
