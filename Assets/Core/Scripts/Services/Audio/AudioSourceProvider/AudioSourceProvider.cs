using Core.Scripts.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.Audio.AudioSourceProvider
{
    public class AudioSourceProvider : MonoBehaviour, IAudioSourceProvider
    {
        [field: SerializeField, ReadOnly] public AudioSource MusicSource { get; private set; }
        [field: SerializeField, ReadOnly] public AudioSource SoundSource { get; private set; }

        #region Editor
        [Button]
        private void setRefs()
        {
            MusicSource = transform.FindDeepChild<AudioSource>("Music Source");
            SoundSource = transform.FindDeepChild<AudioSource>("Sound Source");
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
    }
}