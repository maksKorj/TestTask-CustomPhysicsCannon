using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Scripts.Services
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, IService> m_ServiceMap = new();

        public ServiceLocator RegisterSingle<TService>(TService implementation) where TService : class, IService
        {
            if (implementation == null)
                return this;

            if (m_ServiceMap.ContainsKey(typeof(TService)))
            {
                Debug.LogError($"Service of type {typeof(TService)} already register!");
                return this;
            }

            m_ServiceMap[typeof(TService)] = implementation;
            return this;
        }

        public void UnregisterSingle<TService>() where TService : class, IService
        {
            m_ServiceMap.Remove(typeof(TService));
        }

        public TService GetSingle<TService>() where TService : class, IService
        {
            if (m_ServiceMap.TryGetValue(typeof(TService), out IService value))
            {
                var service = value as TService;

                if (service == null)
                    Debug.LogError($"Service of type {typeof(TService)} wasn't added!");

                return service;
            }
            else
            {
                Debug.LogError($"Service of type {typeof(TService)} wasn't added!");
                return null;
            }
        }
    }
}