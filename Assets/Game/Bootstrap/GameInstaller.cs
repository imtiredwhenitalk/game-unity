using Game.Core.Saving;
using Game.Interfaces;
using UnityEngine;

namespace Game.Bootstrap
{
    public partial class GameInstaller : MonoBehaviour
    {
        [SerializeField] private SaveService saveServicePrefab;

        public void InstallSaveSystem(DependencyContainer container)
        {
            var saveService = Instantiate(saveServicePrefab);
            DontDestroyOnLoad(saveService.gameObject);
            container.Register<ISaveService>(saveService);
        }
    }
}