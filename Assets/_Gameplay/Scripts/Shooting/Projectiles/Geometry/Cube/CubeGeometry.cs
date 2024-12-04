using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Projectiles.Geometry.Cube
{
    public class CubeGeometry
    {
        private readonly float m_Size;
        private readonly Vector3[] m_Vertices;

        public int[] Triangles { get; }
        
        public CubeGeometry(float size)
        {
            m_Size = size;
            Triangles = createTriangles();
            m_Vertices = CreateVertices();
        }

        public Vector3 GetVertex(int index)
        {
            return m_Vertices[index];
        }

        public Vector3[] CreateVertices()
        {
            return new Vector3[]
            {
                new Vector3(-0.5f, -0.5f, -0.5f) * m_Size, // Bottom-back-left
                new Vector3(0.5f, -0.5f, -0.5f) * m_Size, // Bottom-back-right
                new Vector3(0.5f, 0.5f, -0.5f) * m_Size, // Top-back-right
                new Vector3(-0.5f, 0.5f, -0.5f) * m_Size, // Top-back-left
                new Vector3(-0.5f, -0.5f, 0.5f) * m_Size, // Bottom-front-left
                new Vector3(0.5f, -0.5f, 0.5f) * m_Size, // Bottom-front-right
                new Vector3(0.5f, 0.5f, 0.5f) * m_Size, // Top-front-right
                new Vector3(-0.5f, 0.5f, 0.5f) * m_Size // Top-front-left
            };
        }
        
        private int[] createTriangles()
        {
            return new int[]
            {
                // Back face
                0, 2, 1, 0, 3, 2,
                // Front face
                4, 5, 6, 4, 6, 7,
                // Left face
                0, 7, 3, 0, 4, 7,
                // Right face
                1, 2, 6, 1, 6, 5,
                // Top face
                3, 7, 6, 3, 6, 2,
                // Bottom face
                0, 1, 5, 0, 5, 4
            };
        }
    }
}