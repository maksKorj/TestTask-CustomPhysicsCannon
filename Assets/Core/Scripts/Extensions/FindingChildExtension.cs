using System;
using UnityEngine;

namespace Core.Scripts.Extensions
{
    public static class FindingChildExtension
    {
        public static Transform FindDeepChild(this Transform parent, string name)
        {
            if (parent == null) return null;

            var result = parent.Find(name);
            if (result != null)
                return result;

            foreach (Transform child in parent)
            {
                result = child.FindDeepChild(name);
                if (result != null)
                    return result;
            }

            return null;
        }

        public static T FindDeepChild<T>(this Transform parent, string name)
        {
            T result = default;

            var transform = parent.FindDeepChild(name);

            if (transform != null)
            {
                result = (typeof(T) == typeof(GameObject)) ? (T)Convert.ChangeType(transform.gameObject, typeof(T)) : transform.GetComponent<T>();
            }

            if (result == null)
            {
                Debug.LogError($"FindDeepChild didn't find: '{name}' on GameObject: '{parent.name}'");
            }

            return result;
        }
    }
}


