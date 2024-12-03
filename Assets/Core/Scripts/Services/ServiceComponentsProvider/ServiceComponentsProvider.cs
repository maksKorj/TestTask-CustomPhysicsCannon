using Core.Scripts.Services.Audio.AudioSourceProvider;
using Core.Scripts.Services.CameraService;
using Core.Scripts.Services.Gameplay;
using Core.Scripts.Services.Input.Provider;
using Core.Scripts.Services.Level.Provider;
using Core.Scripts.Services.Pool.Base.Provider;
using Core.Scripts.Services.TickProcessor;
using Core.Scripts.Services.UserInterface.Provider;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.ServiceComponentsProvider
{
    public class ServiceComponentsProvider : MonoBehaviour, IServiceComponentsProvider
    {
        [field: SerializeField, ReadOnly] public TickProcessorService TickProcessorService { get; private set; }

        [field: Title("Providers")]
        [SerializeField, ReadOnly] private LevelProvider m_LevelProvider;
        [SerializeField, ReadOnly] private AudioSourceProvider m_AudioSourceProvider;
        [SerializeField, ReadOnly] private InputComponentProvider m_InputComponentProvider;
        [SerializeField, ReadOnly] private PoolProvider m_PoolProvider;

        [field: SerializeField, ReadOnly] public UserInterfaceComponentProvider UiComponentProvider { get; private set; }
        [field: SerializeField, ReadOnly] public CameraProvider CameraProvider { get; private set; }
        [field: SerializeField, ReadOnly] public GameplayObjectProvider GameplayObjectProvider { get; private set; }

        public ILevelProvider LevelProvider => m_LevelProvider;
        public IAudioSourceProvider AudioSourceProvider => m_AudioSourceProvider;
        public IInputComponentProvider InputComponentProvider => m_InputComponentProvider;
        public IPoolProvider PoolProvider => m_PoolProvider;

        ITickProcessorService IServiceComponentsProvider.TickProcessorService => TickProcessorService;

        #region Editor
        [Button]
        private void setRefs()
        {
            TickProcessorService = GetComponentInChildren<TickProcessorService>();

            m_AudioSourceProvider = GetComponentInChildren<AudioSourceProvider>();
            UiComponentProvider = GetComponentInChildren<UserInterfaceComponentProvider>();
            m_InputComponentProvider = GetComponentInChildren<InputComponentProvider>();
            m_PoolProvider = GetComponentInChildren<PoolProvider>();
            CameraProvider = GetComponentInChildren<CameraProvider>();
            m_LevelProvider = GetComponentInChildren<LevelProvider>();
            GameplayObjectProvider = GetComponentInChildren<GameplayObjectProvider>();
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
    }
}
