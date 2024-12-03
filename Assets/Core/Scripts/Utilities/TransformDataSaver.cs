using UnityEngine;

namespace Core.Scripts.Utilities
{
    public class TransformDataSaver
    {
        private Transform m_TargetTransform;

        private bool m_SaveLocal;

        public Transform Parent { get; private set; }
        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }

        public TransformDataSaver(Transform transform)
        {
            m_TargetTransform = transform;
        }

        public void Save(bool saveLocal = false)
        {
            Parent = m_TargetTransform.parent;
            m_SaveLocal = saveLocal;

            if (m_SaveLocal)
            {
                Position = m_TargetTransform.localPosition;
                Rotation = m_TargetTransform.localRotation;
            }
            else
            {
                Position = m_TargetTransform.position;
                Rotation = m_TargetTransform.rotation;
            }
        }

        public void Restore()
        {
            m_TargetTransform.parent = Parent;

            if (m_SaveLocal)
                m_TargetTransform.SetLocalPositionAndRotation(Position, Rotation);
            else
                m_TargetTransform.SetPositionAndRotation(Position, Rotation);
        }
    }
}