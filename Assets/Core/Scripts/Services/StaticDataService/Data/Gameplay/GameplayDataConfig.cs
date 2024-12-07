﻿using _Gameplay.Scripts.Shooting.PhysicsTypes;
using UnityEngine;

namespace Core.Scripts.Services.StaticDataService.Data.Gameplay
{
    public class GameplayDataConfig : ScriptableObject
    {
        [field: SerializeField] public PhysicsConfiguration PhysicsConfiguration {get; private set;}
    }
}