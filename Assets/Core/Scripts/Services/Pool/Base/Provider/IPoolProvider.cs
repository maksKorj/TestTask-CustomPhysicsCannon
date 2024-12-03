using System.Collections.Generic;

namespace Core.Scripts.Services.Pool.Base.Provider
{
    public interface IPoolProvider
    {
        public IEnumerable<PoolBase> Pools { get; }
    }
}