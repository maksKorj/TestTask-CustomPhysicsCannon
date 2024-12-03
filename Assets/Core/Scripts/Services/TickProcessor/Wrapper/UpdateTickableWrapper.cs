using System;

namespace Core.Scripts.Services.TickProcessor.Wrapper
{
    public class UpdateTickableWrapper : TickableWrapper<IUpdateTickable>, IUpdateTickable
    {
        protected override IUpdateTickable Instance => this;

        public UpdateTickableWrapper(ITickProcessorService tickProcessorService, Action onUpdated)
            : base(tickProcessorService, onUpdated)
        {
            //
        }

        public void UpdateTick()
        {
            tick();
        }
    }
}