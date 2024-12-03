namespace Core.Scripts.Services
{
    public interface IServiceLocator
    {
        public TService GetSingle<TService>() where TService : class, IService;
    }
}