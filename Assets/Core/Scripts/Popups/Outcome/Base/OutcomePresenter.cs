using System;
using Core.Scripts.Extensions;
using Core.Scripts.Popups.Base;
using Core.Scripts.Services;
using Core.Scripts.Services.Level;
using Core.Scripts.Services.StaticDataService;

namespace Core.Scripts.Popups.Outcome.Base
{
    public abstract class OutcomePresenter : Presenter<OutcomeView>, IOutcomePresenter
    {
        private readonly ILevelService m_LevelService;

        private int m_Earnings;

        protected abstract string m_LevelDisplayStringFormat { get; }

        public event Action OnCompleted;

        public OutcomePresenter(OutcomeView view, IServiceLocator serviceLocator) : base(view, serviceLocator)
        {
            m_LevelService = serviceLocator.GetSingle<ILevelService>();

            var gameStaticDataService = serviceLocator.GetSingle<IGameStaticDataService>();
        }

        public override void Open()
        {
            m_View.UpdateLevelTitle(m_LevelDisplayStringFormat.Formatted(m_LevelService.CurrentLevel));

            base.Open();

            updateEarnings(getInitialEarnings());
        }

        #region Callbacks
        private void nextLevel()
        {
            m_View.SetInteractable(false);
        }

        protected virtual void multiplyAndLoadNextLevel()
        {
            updateEarnings(m_Earnings * 2);

            nextLevel();
        }

        private void onEndEarningAnimation()
        {
            OnCompleted?.Invoke();
        }
        #endregion

        protected abstract int getInitialEarnings();

        private void updateEarnings(int amount)
        {
            m_Earnings = amount;
            m_View.UpdateEarningDisplay(amount);
        }
    }
}
