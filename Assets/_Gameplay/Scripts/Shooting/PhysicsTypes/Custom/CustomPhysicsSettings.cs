using Sirenix.OdinInspector;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.PhysicsTypes.Custom
{
    [CreateAssetMenu(fileName = nameof(CustomPhysicsSettings), menuName = "Gameplay/CustomPhysics/" + nameof(CustomPhysicsSettings), order = 0)]
    public class CustomPhysicsSettings : ScriptableObject
    {
        [field: Title("")]
        [field: SerializeField] public Vector3 Gravity { get; private set; } = new Vector3(0, -9.81f, 0);
        [field: SerializeField] public float Bounciness { get; private set; } = 0.8f;
        [field: Title("")]
        [field: SerializeField] public float TimeStep { get; private set; } = 0.02f;
        [field: Title("")]
        [field: SerializeField] public LayerMask CollisionMask { get; private set; }
    }
}