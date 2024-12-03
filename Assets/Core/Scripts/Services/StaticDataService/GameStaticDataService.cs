using Core.Scripts.Services.StaticDataService.Data.Audio;
using Core.Scripts.Services.StaticDataService.Data.Gameplay;
using Core.Scripts.Services.StaticDataService.Data.Input;
using Core.Scripts.Services.StaticDataService.Data.PopupData;
using UnityEngine;

namespace Core.Scripts.Services.StaticDataService
{
    public class GameStaticDataService : ScriptableObject, IGameStaticDataService
    {
        [field: SerializeField] public InputDataConfig Input { get; private set; }
        [field: SerializeField] public AudioDataConfig AudioData { get; private set; }
        [field: SerializeField] public PopupDataConfig PopupData { get; private set; }
        [field: SerializeField] public GameplayDataConfig GamePlay { get; private set; }
    }
}