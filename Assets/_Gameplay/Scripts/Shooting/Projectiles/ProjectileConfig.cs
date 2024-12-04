using _Gameplay.Scripts.Shooting.Projectiles.Geometry;
using _Gameplay.Scripts.Shooting.Projectiles.Geometry.Cube;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles
{
    [CreateAssetMenu(fileName = nameof(ProjectileConfig), menuName = "Gameplay/" + nameof(ProjectileConfig))]
    public class ProjectileConfig : ScriptableObject
    {
        [field: SerializeField] public float KillTime { get; private set; } = 7.5f;
        [field: SerializeField] public int BounceAmountBeforeKill { get; private set; } = 1;
        
        [Title("Geometry"), SerializeField] private CubeSettings m_CubeSettings;

        public IGeometryProcessor CreateGeometryProcessor(MeshFilter meshFilter)
        {
            return new CubeGeometryProcessor(meshFilter, m_CubeSettings, new CubeGeometry(m_CubeSettings.Size));
        }
    }
}