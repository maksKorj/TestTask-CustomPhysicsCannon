namespace Core.Scripts.Services.Resettable
{
    public interface IResettableService : IService
    {
        public void Add(IResettable resettable);
        public void Remove(IResettable resettable);
    }
}