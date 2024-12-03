using UnityEngine;

namespace Core.Scripts.Services.Pool.Base
{
    public abstract class PoolBase : MonoBehaviour
    {
        public virtual void Init(IServiceLocator serviceLocator)
        {
            //
        }

        public abstract void ResetPool();

        protected virtual void resetEntity(PoolEntity poolable)
        {
            poolable.transform.parent = transform;
            resetTransform(poolable);
        }

        protected void resetTransform(PoolEntity entity)
        {
            entity.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            entity.transform.localScale = Vector3.one;

            entity.Hide();
        }
    }
}