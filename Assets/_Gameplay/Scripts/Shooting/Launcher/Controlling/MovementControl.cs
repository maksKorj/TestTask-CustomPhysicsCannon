using _Gameplay.Scripts.Shooting.Launcher.Controlling.AxisControl;
using _Gameplay.Scripts.Shooting.Launcher.Controlling.Data;
using Core.Scripts.Services.Input.Modules.SimpleInput;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.Controlling
{
    public class MovementControl
    {
        private readonly IBaseInput m_Input;
        private readonly MovementAxisController[] m_AxisControls;
        
        public MovementControl(IBaseInput input, IMovementControlContext controlContext)
        {
            m_Input = input;

            var movementControlSettings = controlContext.MovementControlSettings;
            m_AxisControls = new MovementAxisController[]
            {
                new HorizontalAxisController(controlContext.Transform, movementControlSettings.Horizontal),
                new VerticalAxisController(controlContext.Barrel, movementControlSettings.Vertical)
            };
        }

        public void Activate()
        {
            m_Input.OnDrag += onDrag;
        }

        public void Deactivate()
        {
            m_Input.OnDrag -= onDrag;
        }

        private void onDrag(Vector2 drag)
        {
            foreach (var control in m_AxisControls)
                control.OnDrag(drag);
        }
    }
}