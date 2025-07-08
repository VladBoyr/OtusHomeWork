using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class ObjectPool<T> : MonoBehaviour
        where T : Object
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

        public void InitializeObject(T obj)
        {
            (obj as MonoBehaviour)?.
        }

        enemy.Initialize(this._weaponService);

        public T CreateObject()
        {
            if (this._objectPool.TryDequeue(out var obj) == false)
            {
                obj = Instantiate(this.objectPrefab);
            }

            return obj;
        }

        public virtual void RemoveObject(T obj)
        {
            var gameObj = obj as GameObject;
            gameObj?.transform.SetParent(this.poolContainer);
            gameObj?.gameObject.SetActive(false);
            this._objectPool.Enqueue(obj);
        }
    }
}