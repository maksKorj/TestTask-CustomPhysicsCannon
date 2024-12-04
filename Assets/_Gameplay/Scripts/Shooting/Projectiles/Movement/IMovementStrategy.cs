using System;
using _Gameplay.Scripts.WorldCollision;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles.Movement
{
    public interface IMovementStrategy
    {
        public event Action<RaycastHit, ICollisionObject> OnCollided;
        
        public void Launch(Vector3 velocity);
        public void Stop();
    }
}