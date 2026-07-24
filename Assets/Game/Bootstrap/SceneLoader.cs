using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Bootstrap
{
    public sealed class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string mainMenusScene = "MainMenu";

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(mainMenusScene);
        }

        public void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}