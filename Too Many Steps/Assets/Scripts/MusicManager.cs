using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    private const string MUSIC_VOLUME = "Music_Volume";
    private float musicVolume;
    private AudioSource myAudio;
    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME,0.3f);
        myAudio.volume = musicVolume;
        volumeSlider.value = musicVolume;
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        int instance = FindObjectsByType<MusicManager>(FindObjectsSortMode.None).Length;
        if(instance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetMusicVolume()
    {
        musicVolume = volumeSlider.value;
        myAudio.volume = musicVolume;
        PlayerPrefs.SetFloat(MUSIC_VOLUME, musicVolume);
    }
}
