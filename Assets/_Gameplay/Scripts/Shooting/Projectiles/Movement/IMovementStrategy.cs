using System;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles.Movement
{
    public interface IMovementStrategy
    {
        public event Action OnCollided;
        
        public void Launch(Vector3 velocity);
        public void Stop();
    }
}