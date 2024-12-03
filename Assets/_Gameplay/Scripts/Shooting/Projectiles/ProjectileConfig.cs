using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles
{
    [CreateAssetMenu(fileName = nameof(ProjectileConfig), menuName = "Gameplay/" + nameof(ProjectileConfig))]
    public class ProjectileConfig : ScriptableObject
    {
        [field: SerializeField] public float KillTime { get; private set; } = 7.5f;
        [field: SerializeField] public int BounceAmountBeforeKill { get; private set; } = 1;
    }
}