using Game.Interfaces;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public class EnemyFactory
    {
        private readonly IPoolService poolService;

        public EnemyFactory(IPoolService poolService)
        {
            this.poolService = poolService;
        }

        public EnemyController Spawn(EnemyController prefab, Vector3 position)
        {
            return poolService.Get(prefab, position, Quaternion.identity);
        }

        public void Despawn(EnemyController enemy)
        {
            poolService.Return(enemy);
        }
    }
}