using System;
using Core.Scripts.Utilities;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.Controlling.Data
{
    [Serializable]
    public class MovementAxisData
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public DataRange<float> Restriction { get; private set; }
    }
}