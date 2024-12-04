using Core.Scripts.Services.UserInterface.Canvas;
using Core.Scripts.Services.UserInterface.Hud.Provider;
using Core.Scripts.Services.UserInterface.TransitionCurtain;

namespace Core.Scripts.Services.UserInterface.Provider
{
    public interface IUserInterfaceComponentProvider : IService
    {
        public ICanvasProvider CanvasProvider { get; }
        public IHudComponentProvider HudComponentProvider { get; }
        public ITransitionCurtain TransitionCurtain { get; }
    }
}