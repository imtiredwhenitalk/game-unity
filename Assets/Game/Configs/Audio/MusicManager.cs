using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip defaultTrack;

    private const string VOLUME_KEY = "MusicVolume";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (musicSource == null)
            musicSource = GetComponent<AudioSource>();

        musicSource.loop = true;

        float savedVolume = PlayerPrefs.GetFloat(VOLUME_KEY, 0.5f);
        SetVolume(savedVolume);
    }

    void Start()
    {
        if (defaultTrack != null && !musicSource.isPlaying)
        {
            musicSource.clip = defaultTrack;
            musicSource.Play();
        }
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    public void PlayTrack(AudioClip clip)
    {
        if (musicSource.clip == clip && musicSource.isPlaying) return;
        musicSource.clip = clip;
        musicSource.Play();
    }
}