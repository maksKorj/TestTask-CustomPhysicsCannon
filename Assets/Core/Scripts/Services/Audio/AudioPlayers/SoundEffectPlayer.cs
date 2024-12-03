using Core.Scripts.Services.StaticDataService.Data;
using Core.Scripts.Services.StaticDataService.Data.Audio;
using UnityEngine;

namespace Core.Scripts.Services.Audio.AudioPlayers
{
    public class SoundEffectPlayer : AudioSourcePlayer
    {
        public AudioDataConfig Sounds { get; private set; }

        public SoundEffectPlayer(AudioSource audioSource, AudioDataConfig audioDataConfig)
            : base(audioSource)
        {
            Sounds = audioDataConfig;
        }

        public void TryPlay(AudioClip audioClip)
        {
            if(m_IsMuted || audioClip == null)
                return;

            m_AudioSource.PlayOneShot(audioClip);
        }
    }
}
