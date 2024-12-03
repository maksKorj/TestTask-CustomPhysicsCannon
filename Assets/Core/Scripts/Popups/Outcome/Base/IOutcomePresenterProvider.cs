namespace Core.Scripts.Popups.Outcome.Base
{
    public interface IOutcomePresenterProvider
    {
        public IOutcomePresenter Presenter { get; }
    }
}