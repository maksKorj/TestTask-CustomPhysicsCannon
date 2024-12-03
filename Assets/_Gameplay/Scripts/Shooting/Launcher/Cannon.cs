using _Gameplay.Scripts.Shooting.Launcher.Controlling;
using _Gameplay.Scripts.Shooting.Launcher.TrajectoryRendering;
using Core.Scripts.Services.Input.Modules.SimpleInput;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher
{
    public class Cannon
    {
        private readonly CannonComponent m_Component;
        private readonly ITrajectoryRenderer m_TrajectoryRenderer;
        private readonly MovementControl m_MovementControl;

        #region Init
        public Cannon(CannonComponent component, ITrajectoryRenderer trajectoryRenderer, IBaseInput input)
        {
            m_Component = component;
            m_TrajectoryRenderer = trajectoryRenderer;

            m_MovementControl = new MovementControl(input, component);
        }
        
        public void SetActive(bool active)
        {
            if(m_Component.gameObject.activeSelf == active)
                return;
            
            m_Component.gameObject.SetActive(active);

            if (active)
                onEnable();
            else
                onDisable();
        }

        private void onEnable()
        {
            m_MovementControl.Activate();
        }

        private void onDisable()
        {
            m_MovementControl.Deactivate();
        }
        #endregion
        
        public void Place(Transform target)
        {
            m_Component.transform.SetPositionAndRotation(target.position, target.rotation);
        }
    }
}
