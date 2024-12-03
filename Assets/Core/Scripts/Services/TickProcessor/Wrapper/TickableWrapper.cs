using System;

namespace Core.Scripts.Services.TickProcessor.Wrapper
{
    public abstract class TickableWrapper<T> where T : ITickable
    {
        private readonly ITickProcessorService m_TickProcessorService;
        private readonly Action m_OnTick;
        
        private bool m_IsActive;

        protected abstract T Instance { get; }

        public TickableWrapper(ITickProcessorService tickProcessorService, Action onTick)
        {
            m_TickProcessorService = tickProcessorService;
            m_OnTick = onTick;
        }

        public void Activate()
        {
            m_IsActive = true;
            m_TickProcessorService.Add(Instance);
        }

        public void Deactivate()
        {
            m_IsActive = false;
            m_TickProcessorService.Remove(Instance);
        }

        protected void tick()
        {
            if (m_IsActive)
            {
                m_OnTick?.Invoke();
            }
        }
    }
}