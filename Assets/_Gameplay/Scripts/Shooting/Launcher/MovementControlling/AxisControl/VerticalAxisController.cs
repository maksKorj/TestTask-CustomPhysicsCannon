using _Gameplay.Scripts.Shooting.Launcher.MovementControlling.Data;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.MovementControlling.AxisControl
{
    public class VerticalAxisController : MovementAxisController
    {
        public VerticalAxisController(Transform transform, MovementAxisData data) : base(transform, data)
        {
            
        }
        
        protected override float getDragAxis(Vector2 drag)
        {
            return -drag.y;
        }
        
        protected override float getCurrentAngle()
        {
            return m_Transform.localEulerAngles.x;
        }
        
        protected override Vector3 getRotation(float newAngle)
        {
            return new Vector3(newAngle, 0, 0);
        }
    }
}