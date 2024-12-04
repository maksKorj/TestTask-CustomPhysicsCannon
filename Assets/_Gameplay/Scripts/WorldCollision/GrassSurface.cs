using _Gameplay.Scripts.Effects;
using UnityEngine;

namespace _Gameplay.Scripts.WorldCollision
{
    public class GrassSurface : LevelCollisionObject
    {
        public override void Collide(RaycastHit hit)
        {
            playEffect(hit, GenericEffect.EntityType.Grass);
        }
    }
}