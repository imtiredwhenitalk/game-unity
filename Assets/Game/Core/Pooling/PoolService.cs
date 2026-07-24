using System.Collections.Generic;
using Game.Interfaces;
using UnityEngine;

namespace Game.Core.Pooling
{
	/// <summary>
	/// Єдина точка входу для роботи з пулами в грі.
	/// Gameplay-системи звертаються сюди, а не напряму до ObjectPool<T>.
	/// </summary>
	public class PoolService : MonoBehaviour, IPoolService
	{
		// Ключ — префаб (через InstanceID), значення — пул відповідного типу.
		private readonly Dictionary<int, object> pools = new();
		private readonly Dictionary<Component, int> instanceToPrefabKey = new();

		public T Get<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent = null) where T : Component
		{
			var pool = GetOrCreatePool(prefab, parent);
			var instance = pool.Get(position, rotation);

			instanceToPrefabKey[instance] = prefab.GetInstanceID();

			if (instance is IPoolable poolable)
				poolable.OnSpawn();

			return instance;
		}

		public void Return<T>(T instance) where T : Component
		{
			if (instance is IPoolable poolable)
				poolable.OnDespawn();

			if (!instanceToPrefabKey.TryGetValue(instance, out var key))
			{
				Debug.LogWarning($"[PoolService] Спроба повернути об'єкт {instance.name}, який не було створено через пул. Знищую напряму.");
				Destroy(instance.gameObject);
				return;
			}

			if (pools.TryGetValue(key, out var poolObj) && poolObj is ObjectPool<T> pool)
			{
				pool.Return(instance);
			}
		}

		public void Prewarm<T>(T prefab, int count, Transform parent = null) where T : Component
		{
			var pool = GetOrCreatePool(prefab, parent);
			var temp = new List<T>(count);

			for (int i = 0; i < count; i++)
				temp.Add(pool.Get(Vector3.zero, Quaternion.identity));

			foreach (var obj in temp)
				pool.Return(obj);
		}

		private ObjectPool<T> GetOrCreatePool<T>(T prefab, Transform parent) where T : Component
		{
			int key = prefab.GetInstanceID();

			if (!pools.TryGetValue(key, out var poolObj))
			{
				var newPool = new ObjectPool<T>(prefab, 0, parent);
				pools[key] = newPool;
				return newPool;
			}

			return (ObjectPool<T>)poolObj;
		}
	}
}