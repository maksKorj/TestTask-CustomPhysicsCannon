using Sirenix.OdinInspector;
using UnityEngine;

namespace _Gameplay.Scripts.Effects
{
    public class GenericEffect : GenericEffectBase
    {
        [field: SerializeField, PropertyOrder(-1)] public EntityType VfxType { get; private set; }

        public enum EntityType
        {
            Explosion,
            Grass,
            WallHit
        }
    }
}
