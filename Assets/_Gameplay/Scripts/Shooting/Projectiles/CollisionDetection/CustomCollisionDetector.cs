using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles.CollisionDetection
{
    public class CustomCollisionDetector : ICollisionDetector
    {
        private readonly Transform m_Transform;
        private readonly MeshFilter m_MeshFilter;
        private readonly LayerMask m_CollisionMask;

        public CustomCollisionDetector(Transform transform, MeshFilter meshFilter, LayerMask collisionMask)
        {
            m_Transform = transform;
            m_MeshFilter = meshFilter;
            m_CollisionMask = collisionMask;
        }

        public bool HasCollision(Vector3 displacement, out RaycastHit hit)
        {
            var vertices = m_MeshFilter.mesh.vertices;
            foreach (var vertex in vertices)
            {
                var worldVertex = m_Transform.TransformPoint(vertex);
                var nextVertexPosition = worldVertex + displacement;

                if (Physics.Linecast(worldVertex, nextVertexPosition, out hit, m_CollisionMask))
                {
                    return true;
                }
            }

            hit = default;
            return false;
        }
        
        public Vector3 CalculateNextPosition(RaycastHit hit)
        {
            var vertices = m_MeshFilter.mesh.vertices;
            var closestVertexOffset = Vector3.zero;
            var minDistance = float.MaxValue;

            foreach (var vertex in vertices)
            {
                var worldVertex = m_Transform.TransformPoint(vertex);
                var distance = Vector3.Distance(worldVertex, hit.point);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestVertexOffset = worldVertex - m_Transform.position;
                }
            }

            return hit.point - closestVertexOffset + hit.normal * 0.01f;
        }
    }
}