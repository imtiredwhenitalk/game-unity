using Game.Interfaces;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public class EnemyController : MonoBehaviour, IPoolable
    {
        [SerializeField] private float maxHealth = 100f;
        private float currentHealth;

        public void OnSpawn()
        {
            currentHealth = maxHealth;
            // тут же скидання аніматора, AI-стану тощо
        }

        public void OnDespawn()
        {
            // відписка від подій, зупинка корутин, скидання таймерів
        }

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                // публікація EnemyKilledEvent через EventBus (окрема система)
            }
        }
    }
}