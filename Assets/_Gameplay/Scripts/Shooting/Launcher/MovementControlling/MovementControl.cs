using _Gameplay.Scripts.Shooting.Launcher.MovementControlling.AxisControl;
using Core.Scripts.Services.Input.Modules.SimpleInput;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.MovementControlling
{
    public class MovementControl : ICannonControl
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
            var normalizedDrag = drag.normalized;
            foreach (var control in m_AxisControls)
                control.OnDrag(normalizedDrag);
        }
    }
}