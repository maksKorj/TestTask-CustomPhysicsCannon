using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles.Movement
{
    public interface IMovementStrategy
    {
        public void Launch(Vector3 velocity);
    }
}