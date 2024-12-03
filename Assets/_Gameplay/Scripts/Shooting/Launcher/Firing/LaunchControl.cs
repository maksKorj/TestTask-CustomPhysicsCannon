using _Gameplay.Scripts.Shooting.Projectiles;
using Core.Scripts.Services.Input.Modules.SimpleInput;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.Firing
{
    public class LaunchControl : ICannonControl
    {
        private readonly Transform m_FiringPoint;
        private readonly IPowerProvider m_PowerProvider;
        private readonly IBaseInput m_Input;
        private readonly ProjectilePool m_ProjectilePool;

        public LaunchControl(Transform firingPoint, IPowerProvider powerProvider, IBaseInput input, ProjectilePool projectilePool)
        {
            m_FiringPoint = firingPoint;
            m_PowerProvider = powerProvider;
            m_Input = input;
            m_ProjectilePool = projectilePool;
        }

        public void Activate()
        {
            m_Input.OnInputUp += onInputUp;
        }

        public void Deactivate()
        {
            m_Input.OnInputUp -= onInputUp;
        }

        #region Callbacks
        private void onInputUp(Vector2 _)
        {
            var projectile = m_ProjectilePool.GetPoolable();
            projectile.transform.position = m_FiringPoint.position;
            
            projectile.Launch(m_PowerProvider.CurrentPower * m_FiringPoint.forward);
        }
        #endregion
    }
}