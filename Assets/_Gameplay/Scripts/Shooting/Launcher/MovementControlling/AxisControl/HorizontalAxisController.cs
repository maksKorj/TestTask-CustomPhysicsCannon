using _Gameplay.Scripts.Shooting.Launcher.MovementControlling.Data;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.MovementControlling.AxisControl
{
    public class HorizontalAxisController : MovementAxisController
    {
        public HorizontalAxisController(Transform transform, MovementAxisData data) : base(transform, data)
        {
            
        }
        
        protected override float getDragAxis(Vector2 drag)
        {
            return drag.x;
        }

        protected override float getCurrentAngle()
        {
            return m_Transform.localEulerAngles.y;
        }

        protected override Vector3 getRotation(float newAngle)
        {
            return new Vector3(0, newAngle, 0);
        }
    }
}