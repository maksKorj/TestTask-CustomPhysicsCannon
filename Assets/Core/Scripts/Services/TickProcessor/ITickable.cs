namespace Core.Scripts.Services.TickProcessor
{
    public interface ITickable
    {

    }

    public interface IUpdateTickable : ITickable
    {
        public void UpdateTick();
    }

    public interface IFixedUpdateTickable : ITickable
    {
        public void FixedUpdateTick();
    }

    public interface ILateUpdateTickable : ITickable
    {
        public void LateUpdateTick();
    }
}