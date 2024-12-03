using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Scripts.Utilities
{
    [Serializable]
    public class DataRange<T> where T : struct
    {
        [field: SerializeField] public T Min { get; private set; }
        [field: SerializeField] public T Max { get; private set; }

        public DataRange(T min, T max)
        {
            Min = min;
            Max = max;
        }
    }

    public static class DataRangeExtension
    {
        public static float GetRandom(this DataRange<float> dataRange)
        {
            return Random.Range(dataRange.Min, dataRange.Max);
        }

        public static int GetRandom(this DataRange<int> dataRange)
        {
            return Random.Range(dataRange.Min, dataRange.Max + 1);
        }
    }
}

