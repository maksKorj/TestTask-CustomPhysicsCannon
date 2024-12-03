using _Gameplay.Scripts.Shooting.Launcher.Controlling.Data;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.Controlling
{
    public interface IMovementControlContext
    {
        public Transform Barrel { get; }
        public Transform Transform { get; }
        
        MovementControlSettings MovementControlSettings { get;}
    }
}