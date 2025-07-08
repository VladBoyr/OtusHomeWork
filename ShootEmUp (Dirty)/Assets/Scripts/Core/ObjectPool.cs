using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class ObjectPool<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        [SerializeField] protected T objectPrefab;
        [SerializeField] protected int initialCount;
        [SerializeField] protected Transform poolContainer;

        private readonly Queue<T> _objectPool = new();

        public void Initialize()
        {
            for (var i = 0; i < this.initialCount; i++)
            {
                var obj = Instantiate(this.objectPrefab, this.poolContainer);
                this._objectPool.Enqueue(obj);
            }
        }

        public T CreateObject()
        {
            if (this._objectPool.TryDequeue(out var obj))
            {
                this.OnTakeFromPool(obj);
                return obj;
            }

            obj = Instantiate(this.objectPrefab, this.poolContainer);
            this.OnTakeFromPool(obj);
            return obj;
        }

        public void RemoveObject(T obj)
        {
            obj.transform.SetParent(this.poolContainer);
            this.OnReturnToPool(obj);
            this._objectPool.Enqueue(obj);
        }

        protected virtual void OnTakeFromPool(T obj)
        {
            obj.gameObject.SetActive(true);
        }

        protected virtual void OnReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}