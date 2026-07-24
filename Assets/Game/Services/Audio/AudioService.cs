// GameInstaller.cs (Bootstrap)
public class GameInstaller : MonoBehaviour
{
    [SerializeField] private AudioManager audioManagerPrefab;

    public void Install(DependencyContainer container)
    {
        var audioManager = Instantiate(audioManagerPrefab);
        DontDestroyOnLoad(audioManager.gameObject);
        container.Register<IAudioService>(audioManager);
    }
}