using Core.Scripts.Services;

namespace Core.Scripts.Popups.Base
{
    public abstract class Presenter<T> where T : View
    {
        protected readonly T m_View;

        protected Presenter(T view, IServiceLocator serviceLocator)
        {
            m_View = view;
        }

        public virtual void Open()
        {
            m_View.Open();
        }

        public virtual void Close(bool closeInstantly = false)
        {
            m_View.Close(closeInstantly);
        }
    }
}
