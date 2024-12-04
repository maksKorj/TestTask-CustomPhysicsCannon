using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles.CollisionDetection
{
    public interface ICollisionDetector
    {
        bool HasCollision(Vector3 displacement, out RaycastHit hit);
        Vector3 CalculateNextPosition(RaycastHit hit);
    }
}