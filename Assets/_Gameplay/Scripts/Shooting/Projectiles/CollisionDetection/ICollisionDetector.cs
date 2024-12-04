using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles.CollisionDetection
{
    public interface ICollisionDetector
    {
        public bool HasCollision(Vector3 displacement, out RaycastHit hit);
        public Vector3 CalculateNextPosition(RaycastHit hit);
    }
}