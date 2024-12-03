using System.Collections;
using System.Collections.Generic;
using Core.Scripts.Services.Input;
using UnityEngine;

namespace Core.Scripts.Services.TickProcessor
{
    public class TickProcessorService : MonoBehaviour, ITickProcessorService
    {
        private readonly HashSet<IFixedUpdateTickable> m_FixedUpdateTickables = new();
        private readonly HashSet<IUpdateTickable> m_UpdateTickables = new();

        private readonly HashSet<IFixedUpdateTickable> m_FixedUpdateToAdd = new();
        private readonly HashSet<IFixedUpdateTickable> m_FixedUpdateToRemove = new();

        private readonly HashSet<IUpdateTickable> m_UpdateToAdd = new();
        private readonly HashSet<IUpdateTickable> m_UpdateToRemove = new();

        private bool m_IsEnabled = true;

        private IUpdateTickable m_InputUpdateTickable;
        private IFixedUpdateTickable m_InputFixedUpdateTickable;

        public void SetActive(bool active)
        {
            m_IsEnabled = active;
        }

        public void AddInput(InputService input)
        {
            m_InputUpdateTickable = input;
            m_InputFixedUpdateTickable = input;
        }

        public void Add(ITickable tickable)
        {
            if (tickable is IFixedUpdateTickable fixedUpdateTickable)
                m_FixedUpdateToAdd.Add(fixedUpdateTickable);

            if (tickable is IUpdateTickable updateTickable)
                m_UpdateToAdd.Add(updateTickable);
        }

        public void Remove(ITickable tickable)
        {
            if (tickable is IFixedUpdateTickable fixedUpdateTickable)
            {
                m_FixedUpdateToAdd.Remove(fixedUpdateTickable);
                m_FixedUpdateToRemove.Add(fixedUpdateTickable);
            }

            if (tickable is IUpdateTickable updateTickable)
            {
                m_UpdateToAdd.Remove(updateTickable);
                m_UpdateToRemove.Add(updateTickable);
            }
        }

        private void Update()
        {
            m_InputUpdateTickable?.UpdateTick();

            if (m_IsEnabled == false)
                return;

            ApplyPendingChanges(m_UpdateTickables, m_UpdateToAdd, m_UpdateToRemove);
            foreach (var tickable in m_UpdateTickables)
            {
                if (!m_UpdateToRemove.Contains(tickable))
                {
                    tickable.UpdateTick();
                }
            }
        }

        private void FixedUpdate()
        {
            m_InputFixedUpdateTickable?.FixedUpdateTick();

            if (m_IsEnabled == false)
                return;

            ApplyPendingChanges(m_FixedUpdateTickables, m_FixedUpdateToAdd, m_FixedUpdateToRemove);
            foreach (var tickable in m_FixedUpdateTickables)
            {
                if (!m_FixedUpdateToRemove.Contains(tickable))
                {
                    tickable.FixedUpdateTick();
                }
            }
        }

        private void ApplyPendingChanges<T>(HashSet<T> tickables, HashSet<T> toAdd, HashSet<T> toRemove)
        {
            foreach (var item in toRemove)
            {
                tickables.Remove(item);
            }
            toRemove.Clear();

            foreach (var item in toAdd)
            {
                tickables.Add(item);
            }
            toAdd.Clear();
        }

        public Coroutine TryStartCoroutine(IEnumerator coroutine)
        {
            if (gameObject.activeInHierarchy == false)
                return null;

            return StartCoroutine(coroutine);
        }
    }
}