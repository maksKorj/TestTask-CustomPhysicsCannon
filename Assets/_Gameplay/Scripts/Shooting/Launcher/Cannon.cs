using _Gameplay.Scripts.Shooting.Launcher.Animation;
using _Gameplay.Scripts.Shooting.Launcher.Firing;
using _Gameplay.Scripts.Shooting.Launcher.MovementControlling;
using _Gameplay.Scripts.Shooting.Launcher.PowerControlling;
using _Gameplay.Scripts.Shooting.Launcher.TrajectoryRendering;
using _Gameplay.Scripts.Shooting.Projectiles;
using Core.Scripts.Services;
using Core.Scripts.Services.Input;
using Core.Scripts.Services.Input.Modules.SimpleInput;
using Core.Scripts.Services.Pool;
using Core.Scripts.Services.TickProcessor;
using Core.Scripts.Services.UserInterface;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher
{
    public class Cannon : IUpdateTickable, IPowerProvider
    {
        private readonly CannonComponent m_Component;
        private readonly ITrajectoryRenderer m_TrajectoryRenderer;
        private readonly PowerControl m_PowerControl;
        private readonly ITickProcessorService m_TickProcessorService;
        
        private readonly ICannonControl[] m_Controls;

        public float CurrentPower { get; private set; }
        
        #region Init
        public Cannon(CannonComponent component, ILauncherAnimator animator, ITrajectoryRenderer trajectoryRenderer, IServiceLocator serviceLocator)
        {
            m_Component = component;
            m_TrajectoryRenderer = trajectoryRenderer;

            var input = serviceLocator.GetSingle<IInputService>().BaseInput;
            
            m_Controls = new ICannonControl[]
            {
                new MovementControl(input, component),
                createLaunchControl(serviceLocator, input, animator)
            };
            m_PowerControl = serviceLocator.GetSingle<IUserInterfaceService>().HudService.GetElement<PowerControl>();
            m_TickProcessorService = serviceLocator.GetSingle<ITickProcessorService>();
        }

        private LaunchControl createLaunchControl(IServiceLocator serviceLocator, IBaseInput input, ILauncherAnimator animator)
        {
            return new LaunchControl(m_Component.FirePoint, 
                animator,
                this,
                input, 
                serviceLocator.GetSingle<IPoolService>().GetPool<ProjectilePool>());
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
            m_Component.LineRenderer.gameObject.SetActive(true);
            
            m_TickProcessorService.Add(this);
            m_PowerControl.OnPowerChanged += onPowerChanged;
            
            m_PowerControl.SetMaxPower(m_Component.ProjectileMaxPower)
                .SetActive(true);
            
            foreach (var control in m_Controls)
                control.Activate();
        }

        private void onDisable()
        {
            m_Component.LineRenderer.gameObject.SetActive(false);
            
            m_TickProcessorService.Remove(this);
            m_PowerControl.OnPowerChanged -= onPowerChanged;
            
            m_PowerControl.SetActive(false);
            
            foreach (var control in m_Controls)
                control.Deactivate();
        }
        #endregion

        #region Callbacks
        private void onPowerChanged(float power)
        {
            CurrentPower = power;
        }
        #endregion
        
        public void Place(Transform target)
        {
            m_Component.transform.SetPositionAndRotation(target.position, target.rotation);
        }

        public void UpdateTick()
        {
            m_TrajectoryRenderer.DrawTrajectory(CurrentPower);
        }
    }
}
