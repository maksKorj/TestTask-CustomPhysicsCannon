using _Gameplay.Scripts.Shooting;
using _Gameplay.Scripts.Shooting.PhysicTypes;
using _Gameplay.Scripts.Shooting.PhysicTypes.Custom;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Services.StaticDataService.Data.Gameplay
{
    public class GameplayDataConfig : ScriptableObject
    {
        [field: SerializeField] public PhysicsConfiguration PhysicsConfiguration {get; private set;}
    }
}