using Core.Scripts.Services.StaticDataService.Data.Audio;
using Core.Scripts.Services.StaticDataService.Data.Gameplay;
using Core.Scripts.Services.StaticDataService.Data.Input;
using Core.Scripts.Services.StaticDataService.Data.PopupData;

namespace Core.Scripts.Services.StaticDataService
{
    public interface IGameStaticDataService : IService
    {
        public AudioDataConfig AudioData { get; }
        public GameplayDataConfig GamePlay { get; }
        public InputDataConfig Input { get; }
        public PopupDataConfig PopupData { get; }
    }
}