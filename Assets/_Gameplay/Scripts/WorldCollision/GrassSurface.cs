using _Gameplay.Scripts.Effects;
using UnityEngine;

namespace _Gameplay.Scripts.WorldCollision
{
    public class GrassSurface : LevelCollisionObject
    {
        public override void Collide(RaycastHit hit)
        {
            m_SoundEffectPlayer.TryPlay(m_SoundEffectPlayer.Sounds.HitGrass);
            playEffect(hit, GenericEffect.EntityType.Grass);
        }
    }
}