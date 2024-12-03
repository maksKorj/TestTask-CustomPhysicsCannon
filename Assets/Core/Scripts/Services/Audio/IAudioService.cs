using Core.Scripts.Services.Audio.AudioPlayers;

namespace Core.Scripts.Services.Audio
{
    public interface IAudioService : IService
    {
        public MusicPlayer MusicPlayer { get; }
        public SoundEffectPlayer SoundEffectPlayer { get; }
    }
}