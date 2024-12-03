using UnityEngine;

namespace Core.Scripts.Services.Audio.AudioSourceProvider
{
    public interface IAudioSourceProvider
    {
        public AudioSource MusicSource { get; }
        public AudioSource SoundSource { get; }
    }
}