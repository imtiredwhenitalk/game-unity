using UnityEngine;

namespace Game.Interfaces
{
    public interface IPoolService
    {
        T Get<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent = null) where T : Component;
        void Return<T>(T instance) where T : Component;
        void Prewarm<T>(T prefab, int count, Transform parent = null) where T : Component;
    }
}