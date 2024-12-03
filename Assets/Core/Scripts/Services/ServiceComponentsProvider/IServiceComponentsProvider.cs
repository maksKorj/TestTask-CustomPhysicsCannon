using Core.Scripts.Services.Audio.AudioSourceProvider;
using Core.Scripts.Services.CameraService;
using Core.Scripts.Services.Gameplay;
using Core.Scripts.Services.Input.Provider;
using Core.Scripts.Services.Level.Provider;
using Core.Scripts.Services.Pool.Base.Provider;
using Core.Scripts.Services.TickProcessor;
using Core.Scripts.Services.UserInterface.Provider;

namespace Core.Scripts.Services.ServiceComponentsProvider
{
    public interface IServiceComponentsProvider
    {
        public IAudioSourceProvider AudioSourceProvider { get; }
        public IInputComponentProvider InputComponentProvider { get; }
        public IPoolProvider PoolProvider { get; }
        public ITickProcessorService TickProcessorService { get; }
        public CameraProvider CameraProvider { get; }
        public ILevelProvider LevelProvider { get; }

        public UserInterfaceComponentProvider UiComponentProvider { get; }
        public GameplayObjectProvider GameplayObjectProvider { get; }
    }
}