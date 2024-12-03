using System;
using Core.Scripts.Services.UserInterface.Hud.Elements.Base;
using UnityEngine;

namespace _Gameplay.Scripts.Shooting.Launcher.PowerControlling
{
    public class PowerControl : IHudElement
    {
        private readonly PowerControlComponent m_Component;

        private const float m_PowerDisplayMultiplier = 100;
        
        private float m_MaxPower;
        
        public event Action<float> OnPowerChanged;

        public PowerControl(PowerControlComponent component)
        {
            m_Component = component;
        }

        public PowerControl SetMaxPower(float power)
        {
            m_MaxPower = power;
            return this;
        }

        public void SetActive(bool active)
        {
            if(m_Component.gameObject.activeSelf == active)
                return;
            
            m_Component.gameObject.SetActive(active);

            if (active)
            {
                m_Component.Slider.value = 0.5f;
                onValueChanged(m_Component.Slider.value);
                
                m_Component.Slider.onValueChanged.AddListener(onValueChanged);
            }
            else
            {
                m_Component.Slider.onValueChanged.RemoveListener(onValueChanged);
            }
        }

        private void onValueChanged(float value)
        {
            m_Component.AmountDisplay.text = Mathf.RoundToInt(value * m_PowerDisplayMultiplier).ToString();
            OnPowerChanged?.Invoke(value * m_MaxPower);
        }
    }
}