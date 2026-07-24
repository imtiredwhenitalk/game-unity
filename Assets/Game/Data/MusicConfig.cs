[CreateAssetMenu(fileName = "MusicConfig", menuName = "Game/Configs/Music Config")]
public class MusicConfig : ScriptableObject
{
    public AudioClip mainMenuTheme;
    public AudioClip[] gameplayTracks;
    public AudioClip bossTheme;
}