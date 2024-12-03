using _Gameplay.Scripts.Shooting.Launcher.MovementControlling.Data;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.MovementControlling
{
    public interface IMovementControlContext
    {
        public Transform Barrel { get; }
        public Transform Transform { get; }
        
        MovementControlSettings MovementControlSettings { get;}
    }
}