using Core.Scripts.Services.UserInterface.Canvas;
using Core.Scripts.Services.UserInterface.Hud;
using Core.Scripts.Services.UserInterface.Popup;
using Core.Scripts.Services.UserInterface.TransitionCurtain;

namespace Core.Scripts.Services.UserInterface
{
    public interface IUserInterfaceService : IService
    {
        public ICanvasProvider CanvasProvider { get; }
        public IHudService HudService { get; }
        public IPopupService PopupService { get; }
        public ITransitionCurtain TransitionCurtain { get; }
    }
}