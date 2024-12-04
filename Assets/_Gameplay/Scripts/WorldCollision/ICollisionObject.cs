using UnityEngine;

namespace _Gameplay.Scripts.WorldCollision
{
    public interface ICollisionObject
    {
        public float BounceMultiplier { get; }
        public void Collide(RaycastHit hit);
    }
}