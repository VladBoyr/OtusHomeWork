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
                InitializeObject(obj);
                this._objectPool.Enqueue(obj);
            }
        }

        protected virtual void InitializeObject(T obj)
        {
        }

        public T CreateObject()
        {
            if (this._objectPool.TryDequeue(out var obj))
                return obj;

            obj = Instantiate(this.objectPrefab, this.poolContainer);
            InitializeObject(obj);
            return obj;
        }

        public virtual void RemoveObject(T obj)
        {
            obj.transform.SetParent(this.poolContainer);
            obj.gameObject.SetActive(false);
            this._objectPool.Enqueue(obj);
        }
    }
}