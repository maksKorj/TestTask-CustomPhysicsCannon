using Core.Scripts.Infrastructure.GameStateMachine.Base;
using Core.Scripts.Popups.Base;
using Core.Scripts.Popups.Outcome.Base;
using Core.Scripts.Services;
using Core.Scripts.Services.UserInterface;
using Core.Scripts.Services.UserInterface.Popup;

namespace Core.Scripts.Infrastructure.GameStateMachine.States.OutcomeStages.Base
{
    public class OutcomeStateBase<T> : IState where T : PopupBase, IOutcomePresenterProvider
    {
        private readonly IGameStateMachine m_StateMachine;
        private readonly IPopupService m_PopupService;

        private IOutcomePresenter m_OutcomePresenter;

        protected OutcomeStateBase(IGameStateMachine stateMachine, IServiceLocator serviceLocator)
        {
            m_StateMachine = stateMachine;
            m_PopupService = serviceLocator.GetSingle<IUserInterfaceService>().PopupService;
        }

        public virtual void Enter()
        {
            m_PopupService.OpenWithAction<T>(subscribe);
        }

        public void Exit()
        {
            m_OutcomePresenter.OnCompleted -= onCompleted;
        }

        private void subscribe(T popup)
        {
            m_OutcomePresenter = popup.Presenter;
            m_OutcomePresenter.OnCompleted += onCompleted;
        }

        private void onCompleted()
        {
            m_StateMachine.Enter<ResetState>();
        }
    }
}