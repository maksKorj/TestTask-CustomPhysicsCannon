using Cinemachine;

namespace Core.Scripts.Services.CameraService
{
    public interface ICameraService : IService
    {
        public CinemachineVirtualCamera PlayerCamera { get; }
    }
}