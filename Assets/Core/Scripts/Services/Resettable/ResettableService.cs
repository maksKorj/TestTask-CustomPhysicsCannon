using System.Collections.Generic;

namespace Core.Scripts.Services.Resettable
{
    public class ResettableService : IResettableService
    {
        private readonly List<IResettable> m_Resettables = new();

        public void Add(IResettable resettable)
        {
            m_Resettables.Add(resettable);
        }

        public void Remove(IResettable resettable)
        {
            m_Resettables.Remove(resettable);
        }

        public void Reset()
        {
            foreach (var resettable in m_Resettables)
                resettable.Reset();

            m_Resettables.Clear();
        }
    }
}
