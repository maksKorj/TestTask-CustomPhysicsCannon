namespace Core.Scripts.Services.CameraService
{
    public class CameraService : ICameraService
    {
        private readonly CameraProvider m_CameraProvider;

        public CameraService(CameraProvider cameraProvider)
        {
            m_CameraProvider = cameraProvider;
        }
    }
}