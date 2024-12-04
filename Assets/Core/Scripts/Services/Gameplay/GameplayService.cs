using _Gameplay.Scripts.Shooting.Launcher;
using _Gameplay.Scripts.Shooting.Launcher.Animation;
using Core.Scripts.Infrastructure;
using Core.Scripts.Services.Audio;
using Core.Scripts.Services.Audio.AudioPlayers;
using Core.Scripts.Services.CameraService;
using Core.Scripts.Services.Input;
using Core.Scripts.Services.StaticDataService;
using UnityEngine;

namespace Core.Scripts.Services.Gameplay
{
    public class GameplayService : IGameplayService
    {
        private readonly GameplayObjectProvider m_Provider;

        public Cannon Cannon { get; private set; }

        public GameplayService(GameplayObjectProvider gameplayObjectProvider, IServiceLocator serviceLocator)
        {
            m_Provider = gameplayObjectProvider;

            ServiceRegistrar.OnRegistered += onOnRegistered;
        }

        private void onOnRegistered(IServiceLocator serviceLocator)
        {
            Cannon = createCannon(serviceLocator);
        }

        private Cannon createCannon(IServiceLocator serviceLocator)
        {
            var cannonComponent = m_Provider.CannonComponent;
            var gameplayData = serviceLocator.GetSingle<IGameStaticDataService>().GamePlay;

            var playerCamera = serviceLocator.GetSingle<ICameraService>().PlayerCamera;
            playerCamera.transform.SetParent(cannonComponent.CameraPoint);
            playerCamera.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

            cannonComponent.SetupLineRenderer();

            var launcherAnimation = new LauncherAnimator(cannonComponent,
                playerCamera,
                serviceLocator.GetSingle<IAudioService>().SoundEffectPlayer);

            return new Cannon(cannonComponent,
                launcherAnimation,
                gameplayData.PhysicsConfiguration.CreateTrajectoryRenderer(cannonComponent),
                serviceLocator);
        }
    }
}