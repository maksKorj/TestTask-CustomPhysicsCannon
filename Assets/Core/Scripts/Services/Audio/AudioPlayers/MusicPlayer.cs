using UnityEngine;

namespace Core.Scripts.Services.Audio.AudioPlayers
{
    public class MusicPlayer : AudioSourcePlayer
    {
        public MusicPlayer(AudioSource audioSource) 
            : base(audioSource)
        {

        }

        public void TryPlay(AudioClip soundtrack)
        {
            if (m_IsMuted)
                return;

            if (soundtrack != null)
            {
                m_AudioSource.clip = soundtrack;
            }
            else
            {
                return;
            }

            play();
        }

        public void Stop()
        {
            if (m_AudioSource.isPlaying == false)
                return;

            m_AudioSource.Stop();
        }

        private void play()
        {
            if (m_AudioSource.isPlaying || m_AudioSource.clip == null)
            {
                return;
            }

            m_AudioSource.Play();
        }
    }
}
