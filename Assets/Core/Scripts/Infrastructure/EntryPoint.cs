using Core.Scripts.Services;
using Core.Scripts.Services.Resettable;
using Core.Scripts.Services.ServiceComponentsProvider;
using Core.Scripts.Services.UserInterface.TransitionCurtain;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Infrastructure
{
    [RequireComponent(typeof(ServiceComponentsProvider))]  
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField, ReadOnly] private ServiceComponentsProvider m_ServiceComponentsProvider;

        private Game m_Game;
        private ResettableService m_ResettableService;

        #region Editor
        [Button]
        private void setRefs()
        {
            m_ServiceComponentsProvider = GetComponentInChildren<ServiceComponentsProvider>();
        }

        private void OnValidate()
        {
            setRefs();
        }
        #endregion

        #region Init
        private void Awake()
        {
            var transitionCurtain = initCurtain();
            var services = registerServices();

            m_Game = new Game(services);
            m_Game.Start();

            transitionCurtain.FadeOut();
        }

        private void OnDisable()
        {
            m_ResettableService.Reset();
        }
        #endregion

        private TransitionCurtain initCurtain()
        {
            var transitionCurtain = m_ServiceComponentsProvider.UiComponentProvider.TransitionCurtain;
            transitionCurtain.MakeBlack();
            
            return transitionCurtain;
        }

        private ServiceLocator registerServices()
        {
            var services = new ServiceLocator();

            var serviceRegistrar = new ServiceRegistrar(m_ServiceComponentsProvider);
            serviceRegistrar.RegisterServices(services, out m_ResettableService);

            return services;
        }
    }
}