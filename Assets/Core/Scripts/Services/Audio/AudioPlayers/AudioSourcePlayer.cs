using UnityEngine;

namespace Core.Scripts.Services.Audio.AudioPlayers
{
    public abstract class AudioSourcePlayer
    {
        protected readonly AudioSource m_AudioSource;

        private readonly bool m_IsOn;

        protected bool m_IsMuted => m_IsOn == false;

        protected AudioSourcePlayer(AudioSource audioSource)
        {
            m_AudioSource = audioSource;
            m_IsOn = true;
        }
    }
}
