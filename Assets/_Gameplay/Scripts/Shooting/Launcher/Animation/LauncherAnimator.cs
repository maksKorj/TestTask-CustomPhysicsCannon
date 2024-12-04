using Cinemachine;
using Core.Scripts.Services.Audio.AudioPlayers;
using DG.Tweening;

namespace _Gameplay.Scripts.Shooting.Launcher.Animation
{
    public class LauncherAnimator : ILauncherAnimator
    {
        private readonly CannonComponent m_Component;
        private readonly SoundEffectPlayer m_SoundEffectPlayer;
        private readonly CinemachineBasicMultiChannelPerlin m_BasicMultiChannelPerlin;
        
        private Tween m_BarrelTween;
        private Tween m_CameraShakeTween;
        
        public LauncherAnimator(CannonComponent component, CinemachineVirtualCamera playerCamera, SoundEffectPlayer soundEffectPlayer)
        {
            m_Component = component;
            m_SoundEffectPlayer = soundEffectPlayer;
            m_BasicMultiChannelPerlin = playerCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        
        public void PlayLaunchAnimation()
        {
            m_Component.LaunchVFX.Play();
            m_SoundEffectPlayer.TryPlay(m_SoundEffectPlayer.Sounds.CannonLauch);

            playBarrelAnimation();
            playCameraAnimation();
            
        }

        private void playBarrelAnimation()
        {
            if(m_BarrelTween.IsActive())
                return;
            
            var barrel = m_Component.Barrel;
            m_BarrelTween = barrel.DOPunchPosition(barrel.forward * -1f, 0.5f);
        }

        private void playCameraAnimation()
        {
            if(m_CameraShakeTween.IsActive())
                return;

            m_CameraShakeTween = DOVirtual.Float(m_Component.CameraShakeAmplitude, 0, 0.5f, (value) =>
            {
                m_BasicMultiChannelPerlin.m_AmplitudeGain = value;
            }).OnComplete(() =>
            {
                m_BasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            });
        }
    }
}