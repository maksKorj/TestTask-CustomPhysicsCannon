using Core.Scripts.Services.UserInterface.Hud.Elements.Base;

namespace Core.Scripts.Services.UserInterface.Hud
{
    public interface IHudService
    {
        public T GetElement<T>() where T : IHudElement;
    }
}