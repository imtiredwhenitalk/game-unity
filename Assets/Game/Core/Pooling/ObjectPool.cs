using System.Collections.Generic;
using Game.Interfaces;
using UnityEngine;

namespace Game.Core.Pooling
{
    /// <summary>
    /// Generic-пул для одного конкретного префаба.
    /// Не знає нічого про геймплей — суто механізм перевикористання об'єктів.
    /// </summary>
    public class ObjectPool<T> where T : Component
    {
        private readonly Queue<T> available = new();
        private readonly T prefab;
        private readonly Transform parent;

        public ObjectPool(T prefab, int initialSize, Transform parent = null)
        {
            this.prefab = prefab;
            this.parent = parent;

            for (int i = 0; i < initialSize; i++)
                available.Enqueue(CreateNew());
        }

        private T CreateNew()
        {
            var instance = Object.Instantiate(prefab, parent);
            instance.gameObject.SetActive(false);
            return instance;
        }

        public T Get(Vector3 position, Quaternion rotation)
        {
            var instance = available.Count > 0 ? available.Dequeue() : CreateNew();
            instance.transform.SetPositionAndRotation(position, rotation);
            instance.gameObject.SetActive(true);
            return instance;
        }

        public void Return(T instance)
        {
            instance.gameObject.SetActive(false);
            instance.transform.SetParent(parent);
            available.Enqueue(instance);
        }
    }
}