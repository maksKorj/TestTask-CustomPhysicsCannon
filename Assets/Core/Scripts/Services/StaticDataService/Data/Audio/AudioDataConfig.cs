using UnityEngine;

namespace Core.Scripts.Services.StaticDataService.Data.Audio
{
    public class AudioDataConfig : ScriptableObject
    {
        [field: SerializeField] public AudioClip Soundtrack { get; private set; }
        [field: SerializeField] public AudioClip CannonLauch { get; private set; }
        [field: SerializeField] public AudioClip HitGrass { get; private set; }
        [field: SerializeField] public AudioClip HitWall { get; private set; }
        [field: SerializeField] public AudioClip Explosion { get; private set; }
    }
}