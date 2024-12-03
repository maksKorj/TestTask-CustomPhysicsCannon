using System;
using Core.Scripts.Services;
using Core.Scripts.Services.Audio;
using Core.Scripts.Services.CameraService;
using Core.Scripts.Services.Gameplay;
using Core.Scripts.Services.Input;
using Core.Scripts.Services.Level;
using Core.Scripts.Services.Pool;
using Core.Scripts.Services.Resettable;
using Core.Scripts.Services.ServiceComponentsProvider;
using Core.Scripts.Services.StaticDataService;
using Core.Scripts.Services.StaticDataService.Data.Audio;
using Core.Scripts.Services.UserInterface;
using UnityEngine;

namespace Core.Scripts.Infrastructure
{
    public class ServiceRegistrar
    {
        private readonly IServiceComponentsProvider m_ComponentsProvider;

        public static event Action<IServiceLocator> OnRegistered;

        public ServiceRegistrar(IServiceComponentsProvider componentsProvider)
        {
            m_ComponentsProvider = componentsProvider;
        }

        public void RegisterServices(ServiceLocator serviceLocator, out ResettableService resettableService)
        {
            var gameStaticDataService = registerGameStaticDataService(serviceLocator);

            serviceLocator.RegisterSingle<ICameraService>(new CameraService(m_ComponentsProvider.CameraProvider))
                .RegisterSingle(m_ComponentsProvider.TickProcessorService);

            resettableService = new ResettableService();
            registerAudioService(serviceLocator, gameStaticDataService.AudioData);
            registerPoolService(serviceLocator);

            serviceLocator.RegisterSingle<IResettableService>(resettableService)
                .RegisterSingle<IGameplayService>(new GameplayService(m_ComponentsProvider.GameplayObjectProvider, serviceLocator))
                .RegisterSingle<ILevelService>(registerLevelService(serviceLocator))
                .RegisterSingle<IUserInterfaceService>(new UserInterfaceService(serviceLocator, m_ComponentsProvider.UiComponentProvider));

            registerInput(serviceLocator);

            OnRegistered?.Invoke(serviceLocator);
        }

        private void registerPoolService(ServiceLocator serviceLocator)
        {
            var poolService = new PoolService(m_ComponentsProvider.PoolProvider.Pools);
            serviceLocator.RegisterSingle<IPoolService>(poolService);

            poolService.InitPools(serviceLocator);
        }

        private GameStaticDataService registerGameStaticDataService(ServiceLocator serviceLocator)
        {
            var gameStaticDataService = Resources.Load<GameStaticDataService>("GameStaticDataService");
            serviceLocator.RegisterSingle<IGameStaticDataService>(gameStaticDataService);

            return gameStaticDataService;
        }

        private LevelService registerLevelService(IServiceLocator serviceLocator)
        {
            var levelService = new LevelService(m_ComponentsProvider.LevelProvider,
                serviceLocator);

            return levelService;
        }

        private AudioService registerAudioService(ServiceLocator serviceLocator, AudioDataConfig audioDataConfig)
        {
            var audioService = new AudioService(m_ComponentsProvider.AudioSourceProvider, audioDataConfig);
            serviceLocator.RegisterSingle<IAudioService>(audioService);

            return audioService;
        }

        private void registerInput(ServiceLocator serviceLocator)
        {
            var inputServiceRegistrar = new InputServiceRegistrar(serviceLocator);

            var inputService = inputServiceRegistrar.RegisterService(
                m_ComponentsProvider.InputComponentProvider,
                m_ComponentsProvider.CameraProvider.MainCamera);

            serviceLocator.RegisterSingle(inputService);
        }
    }
}