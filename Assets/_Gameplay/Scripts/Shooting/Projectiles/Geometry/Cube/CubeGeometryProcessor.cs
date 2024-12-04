using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles.Geometry.Cube
{
    public class CubeGeometryProcessor : IGeometryProcessor
    {
        private readonly MeshFilter m_MeshFilter;
        private readonly CubeSettings m_Settings;
        private readonly CubeGeometry m_Geometry;
        
        private readonly Vector3[] m_Vertices;

        public CubeGeometryProcessor(MeshFilter meshFilter, CubeSettings settings, CubeGeometry geometry)
        {
            m_MeshFilter = meshFilter;
            m_Settings = settings;
            m_Geometry = geometry;

            m_Vertices = m_Geometry.CreateVertices();
        }
        
        public void Process()
        {
            for (int i = 0; i < m_Vertices.Length; i++)
            {
                m_Vertices[i] = m_Geometry.GetVertex(i) + getOffset();
            }

            var mesh = new Mesh
            {
                vertices = m_Vertices,
                triangles = m_Geometry.Triangles
            };
            
            mesh.RecalculateNormals ();
            m_MeshFilter.mesh = mesh;
        }

        private Vector3 getOffset()
        {
            return new Vector3(
                getAxisOffset(),
                getAxisOffset(),
                getAxisOffset()
            );
        }

        private float getAxisOffset()
        {
            return Random.Range(-m_Settings.VertexOffsetRange, m_Settings.VertexOffsetRange);
        }
    }
}
