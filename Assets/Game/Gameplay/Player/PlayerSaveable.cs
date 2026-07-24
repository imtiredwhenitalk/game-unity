using System;
using Game.Interfaces;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public class PlayerSaveable : MonoBehaviour, ISaveable
    {
        [SerializeField] private PlayerHealth health;
        [SerializeField] private PlayerInventory inventory;

        public string SaveId => "Player_Main";

        private ISaveService saveService;

        // saveService приходить через DI (DependencyContainer)
        public void Construct(ISaveService saveService)
        {
            this.saveService = saveService;
            saveService.Register(this);
        }

        private void OnDestroy()
        {
            saveService?.Unregister(this);
        }

        public object CaptureState()
        {
            return new PlayerState
            {
                positionX = transform.position.x,
                positionY = transform.position.y,
                positionZ = transform.position.z,
                currentHealth = health.CurrentHealth,
                inventoryJson = inventory.SerializeToJson()
            };
        }

        public void RestoreState(object state)
        {
            var json = state as string;
            var data = JsonUtility.FromJson<PlayerState>(json);

            transform.position = new Vector3(data.positionX, data.positionY, data.positionZ);
            health.SetHealth(data.currentHealth);
            inventory.RestoreFromJson(data.inventoryJson);
        }

        [Serializable]
        private class PlayerState
        {
            public float positionX, positionY, positionZ;
            public float currentHealth;
            public string inventoryJson;
        }
    }
}