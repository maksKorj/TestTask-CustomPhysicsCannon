using Core.Scripts.Services.UserInterface.Canvas;
using Core.Scripts.Services.UserInterface.Hud;
using Core.Scripts.Services.UserInterface.Provider;
using Core.Scripts.Services.UserInterface.TransitionCurtain;

namespace Core.Scripts.Services.UserInterface
{
    public class UserInterfaceService : IUserInterfaceService
    {
        public ICanvasProvider CanvasProvider { get; private set; }
        public IHudService HudService { get; private set; }
        public ITransitionCurtain TransitionCurtain {get; private set;}

        public UserInterfaceService(IServiceLocator serviceLocator, IUserInterfaceComponentProvider provider)
        {
            HudService = new HudService(provider.HudComponentProvider);
            
            CanvasProvider = provider.CanvasProvider;
            TransitionCurtain = provider.TransitionCurtain;
        }
    }
}