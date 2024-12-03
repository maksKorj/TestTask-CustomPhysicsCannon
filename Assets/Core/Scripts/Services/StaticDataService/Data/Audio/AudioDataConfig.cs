using UnityEngine;

namespace Core.Scripts.Services.StaticDataService.Data.Audio
{
    public class AudioDataConfig : ScriptableObject
    {
        [field: SerializeField] public AudioClip Soundtrack { get; private set; }
    }
}