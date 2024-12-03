using _Gameplay.Scripts.Shooting.Launcher.MovementControlling.Data;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.MovementControlling.AxisControl
{
    public abstract class MovementAxisController
    {
        protected readonly Transform m_Transform;
        protected readonly MovementAxisData m_Data;

        protected MovementAxisController(Transform transform, MovementAxisData data)
        {
            m_Transform = transform;
            m_Data = data;
        }
        
        public void OnDrag(Vector2 drag)
        {
            var rotationChange = getDragAxis(drag) * m_Data.Speed * Time.deltaTime;
            var currentAngle = getCurrentAngle();

            currentAngle = (currentAngle > 180) ? currentAngle - 360 : currentAngle;

            var newAngle = Mathf.Clamp(currentAngle + rotationChange, m_Data.Restriction.Min, m_Data.Restriction.Max);

            m_Transform.localEulerAngles = getRotation(newAngle);
        }

        protected abstract float getDragAxis(Vector2 drag);
        protected abstract float getCurrentAngle();
        protected abstract Vector3 getRotation(float newAngle);
    }
}