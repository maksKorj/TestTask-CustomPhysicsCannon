using Sirenix.OdinInspector;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles.Geometry.Cube
{
    [CreateAssetMenu(menuName = "Gameplay/MeshGeneration/Cube")]
    public class CubeSettings : ScriptableObject
    {
        [field: Title("Timing")]
        [field: SerializeField] public float TimeBetweenDeformation { get; private set; } = 0.5f;
        [field: SerializeField] public float SmoothSpeed { get; private set; } = 15f;
        
        [field: Title("Geometry")]
        [field: SerializeField] public float Size { get; private set; } = 3;
        [field: SerializeField] public float VertexOffsetRange { get; private set; } = 0.2f;
    }
}