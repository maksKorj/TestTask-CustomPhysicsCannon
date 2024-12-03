using System;

namespace Core.Scripts.Popups.GameStart.Start.Presenter
{
    public interface IStartPresenter
    {
        public event Action OnPlayButtonClick;

        public void Setup(int currentLevel);
    }
}