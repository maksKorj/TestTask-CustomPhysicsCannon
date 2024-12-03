using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Scripts.Services.Input.Modules.MultiTouch
{
    public class MultiTouchModule : IMultiTouch
    {
        private readonly float m_FinalDPI;

        private List<Touch> m_InitTouchListNormalized = new();
        private List<Touch> m_LastTouchListNormalized = new();

        private readonly List<Touch> m_CurrTouchListNormalized = new();

        private float m_TouchZoom;
        private float m_TouchZoomDelta;

        public event Action<float> OnTouchZoomDelta;
        public event Action<float> OnTouchZoom;

        public float TouchZoomDelta => m_TouchZoomDelta;
        public float TouchZoom => m_TouchZoom;

        public MultiTouchModule(float finalDPI)
        {
            m_FinalDPI = finalDPI;
        }

        public void Clear()
        {
            m_InitTouchListNormalized.Clear();
            m_LastTouchListNormalized.Clear();
        }

        public void ResetTouchLists()
        {
            m_TouchZoom = m_TouchZoomDelta = 0;

            cloneTouchList(ref m_InitTouchListNormalized, m_CurrTouchListNormalized);
            cloneTouchList(ref m_LastTouchListNormalized, m_CurrTouchListNormalized);
        }

        public void CalculateMultiTouch(Vector3 mousePosNormalized)
        {
            calculateCurrTouchList(mousePosNormalized);

            if (m_CurrTouchListNormalized.Count != m_InitTouchListNormalized.Count)
                ResetTouchLists();

            if (m_CurrTouchListNormalized.Count >= 2)
            {
                if ((m_InitTouchListNormalized[0].fingerId != m_CurrTouchListNormalized[0].fingerId) ||
                    (m_InitTouchListNormalized[1].fingerId != m_CurrTouchListNormalized[1].fingerId))
                {
                    ResetTouchLists();
                }
                else
                {
                    m_TouchZoom = Vector3.Distance(m_CurrTouchListNormalized[0].position, m_CurrTouchListNormalized[1].position) -
                                  Vector3.Distance(m_InitTouchListNormalized[0].position, m_InitTouchListNormalized[1].position);

                    m_TouchZoomDelta = Vector3.Distance(m_CurrTouchListNormalized[0].position, m_CurrTouchListNormalized[1].position) -
                                       Vector3.Distance(m_LastTouchListNormalized[0].position, m_LastTouchListNormalized[1].position);

                    cloneTouchList(ref m_LastTouchListNormalized, m_CurrTouchListNormalized);

                    if (m_TouchZoomDelta != 0)
                    {
                        OnTouchZoom?.Invoke(TouchZoom);
                        OnTouchZoomDelta?.Invoke(TouchZoomDelta);
                    }
                }
            }
        }

        private void calculateCurrTouchList(Vector2 mousePosNormalized)
        {
            m_CurrTouchListNormalized.Clear();
            foreach (Touch touch in UnityEngine.Input.touches)
            {
                if (touch.phase == TouchPhase.Began ||
                    touch.phase == TouchPhase.Moved ||
                    touch.phase == TouchPhase.Stationary)
                {
                    Touch touchNormalized = touch;
                    touchNormalized.position /= m_FinalDPI;
                    m_CurrTouchListNormalized.Add(touchNormalized);
                }
            }

#if UNITY_EDITOR
            if (UnityEngine.Input.GetMouseButton(0) && UnityEngine.Input.GetKey(KeyCode.LeftControl))
            {
                Touch newTouch01 = new Touch { fingerId = 0, position = mousePosNormalized };
                m_CurrTouchListNormalized.Add(newTouch01);

                Touch newTouch02 = new Touch { fingerId = 1, position = Vector2.zero };
                m_CurrTouchListNormalized.Add(newTouch02);
            }
#endif
        }

        private void cloneTouchList(ref List<Touch> i_TouchesRef, List<Touch> i_ListToCopyFrom)
        {
            i_TouchesRef.Clear();
            i_TouchesRef.AddRange(i_ListToCopyFrom);
        }
    }
}

