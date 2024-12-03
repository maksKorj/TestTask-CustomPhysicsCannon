using Core.Scripts.Services.Input;
using Core.Scripts.Utilities;

namespace Core.Scripts.Services.TickProcessor
{
    public interface ITickProcessorService : IService, ICoroutineRunner
    {
        public void SetActive(bool active);

        public void Add(ITickable tickable);
        public void AddInput(InputService input);

        public void Remove(ITickable tickable);
    }
}