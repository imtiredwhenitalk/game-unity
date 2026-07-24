using UnityEngine;

namespace Game.Bootstrap

{
    public sealed class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private GameInstaller installer;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            InitializeGame();
        }

        private void InitializeGame()
        {
            installer.Install();

            sceneLoader.LoadMainMenu();
        }
    }
}