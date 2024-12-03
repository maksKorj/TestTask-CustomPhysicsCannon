namespace Core.Scripts.Services.Pool.Base
{
    public interface IPool<T> where T : PoolEntity
    {
        public T GetPoolable();
        public void ResetPool();
    }
}