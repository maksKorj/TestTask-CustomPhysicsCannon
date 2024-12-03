using System;
using UnityEngine;

namespace Core.Scripts.Services.Pool.Base
{
    public abstract class PoolEntity : MonoBehaviour
    {
        public event Action<PoolEntity> OnTakenBack;

        public virtual void Hide(bool takeBack = false)
        {
            gameObject.SetActive(false);
            if (takeBack)
                this.takeBack();
        }

        protected void takeBack() => OnTakenBack?.Invoke(this);
    }
}
