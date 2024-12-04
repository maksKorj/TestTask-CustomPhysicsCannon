using _Gameplay.Scripts.Effects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Gameplay.Scripts.WorldCollision
{
    public class SurfaceMarkDrawer : LevelCollisionObject
    {
        [Title("MarkSettings")]
        [SerializeField] private Texture2D m_MarkTexture;
        [SerializeField] private float m_MarkSize = 0.1f;
        [Title("Components")]
        [SerializeField, ReadOnly] private MeshRenderer m_MeshRenderer;
        
        private RenderTexture m_RenderTexture;    

        private static readonly int m_RenderTextruePath = Shader.PropertyToID("_RenderTex");

        #region Editor

        [Button]
        private void setRefs()
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion
        
        private void Awake()
        {
            m_RenderTexture = new RenderTexture(256, 256, 24); 
            m_RenderTexture.Create();

            m_MeshRenderer.material.SetTexture(m_RenderTextruePath, m_RenderTexture);
        }
        
        public override void Collide(RaycastHit hit)
        {
            drawTexture(hit);
            playEffect(hit, GenericEffect.EntityType.WallHit);
        }

        private void drawTexture(RaycastHit hit)
        {
            Vector2 uv = hit.textureCoord;

            RenderTexture.active = m_RenderTexture;

            GL.PushMatrix();
            GL.LoadPixelMatrix(0, m_RenderTexture.width, 0, m_RenderTexture.height);

            int x = (int)(uv.x * m_RenderTexture.width);
            int y = (int)(uv.y * m_RenderTexture.height);
            int size = (int)(m_MarkSize * m_RenderTexture.width);

            Graphics.DrawTexture(
                new Rect(x - size / 2, y - size / 2, size, size),
                m_MarkTexture
            );

            GL.PopMatrix();
            RenderTexture.active = null;
        }
    }
}