using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles.Geometry.Cube
{
    public class CubeGeometryProcessor : IGeometryProcessor
    {
        private readonly MeshFilter m_MeshFilter;
        private readonly CubeSettings m_Settings;
        private readonly CubeGeometry m_Geometry;

        private readonly Vector3[] m_Vertices;
        private readonly Vector3[] m_TargetOffsets; 
        private readonly Vector3[] m_CurrentOffsets;

        public CubeGeometryProcessor(MeshFilter meshFilter, CubeSettings settings, CubeGeometry geometry)
        {
            m_MeshFilter = meshFilter;
            m_Settings = settings;
            m_Geometry = geometry;

            m_Vertices = m_Geometry.CreateVertices();
            m_TargetOffsets = new Vector3[m_Vertices.Length];
            m_CurrentOffsets = new Vector3[m_Vertices.Length];
        }

        public void Reset()
        {
            for (int i = 0; i < m_Vertices.Length; i++)
            {
                m_TargetOffsets[i] = GetRandomOffset();
                m_CurrentOffsets[i] = Vector3.zero;
            }
        }

        public void Process()
        {
            for (int i = 0; i < m_Vertices.Length; i++)
            {
                m_CurrentOffsets[i] =
                    Vector3.Lerp(m_CurrentOffsets[i], m_TargetOffsets[i], Time.deltaTime * m_Settings.SmoothSpeed);
            }

            for (int i = 0; i < m_Vertices.Length; i++)
            {
                m_Vertices[i] = m_Geometry.GetVertex(i) + m_CurrentOffsets[i];
            }

            var mesh = new Mesh
            {
                vertices = m_Vertices,
                triangles = m_Geometry.Triangles
            };

            mesh.RecalculateNormals();
            m_MeshFilter.mesh = mesh;

            for (int i = 0; i < m_Vertices.Length; i++)
            {
                if (Random.value < 0.05f)
                {
                    m_TargetOffsets[i] = GetRandomOffset();
                }
            }
        }

        private Vector3 GetRandomOffset()
        {
            return new Vector3(
                GetAxisOffset(),
                GetAxisOffset(),
                GetAxisOffset()
            );
        }

        private float GetAxisOffset()
        {
            return Random.Range(-m_Settings.VertexOffsetRange, m_Settings.VertexOffsetRange);
        }
    }
}