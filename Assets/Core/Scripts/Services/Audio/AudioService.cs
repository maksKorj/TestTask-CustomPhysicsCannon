using Core.Scripts.Services.Audio.AudioPlayers;
using Core.Scripts.Services.Audio.AudioSourceProvider;
using Core.Scripts.Services.StaticDataService.Data.Audio;

namespace Core.Scripts.Services.Audio
{
    public class AudioService : IAudioService
    {
        public SoundEffectPlayer SoundEffectPlayer { get; }
        public MusicPlayer MusicPlayer { get; }

        public AudioService(IAudioSourceProvider audioSourceProvider, AudioDataConfig audioDataConfig)
        {
            SoundEffectPlayer = new SoundEffectPlayer(audioSourceProvider.SoundSource, audioDataConfig);
            MusicPlayer = new MusicPlayer(audioSourceProvider.MusicSource);
        }
    }
}
