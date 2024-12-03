using System;

namespace Core.Scripts.Services.TickProcessor.Wrapper
{
    public class FixedUpdateTickalbeWrapper : TickableWrapper<IFixedUpdateTickable>, IFixedUpdateTickable
    {
        protected override IFixedUpdateTickable Instance => this;

        public FixedUpdateTickalbeWrapper(ITickProcessorService tickProcessorService, Action onFixedUpdated) 
            : base(tickProcessorService, onFixedUpdated)
        {
            //
        }

        public void FixedUpdateTick()
        {
            tick();
        }
    }
}