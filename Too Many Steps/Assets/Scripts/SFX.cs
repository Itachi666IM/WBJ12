using UnityEngine;
using UnityEngine.UI;

public class SFX : MonoBehaviour
{
    public const string SFX_VOLUME = "SFX_Volume";
    public static SFX Instance { get; private set; }
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private Slider volumeSlider;

    private AudioSource myAudio;
    private void Awake()
    {
        Instance = this;
        myAudio = GetComponent<AudioSource>();
        myAudio.volume = PlayerPrefs.GetFloat(SFX_VOLUME,0.3f);
        volumeSlider.value = myAudio.volume;
        DontDestroyOnLoad(gameObject);
    }

    public void SetVolume()
    {
        myAudio.volume = volumeSlider.value;
        PlayerPrefs.SetFloat(SFX_VOLUME, volumeSlider.value);
    }

    private void PlayAnySoundOnce(AudioClip audioToPlay)
    {
        myAudio.pitch = Random.Range(0.75f, 1.25f);
        myAudio.PlayOneShot(audioToPlay);
    }

    public void PlayClickSound()
    {
        PlayAnySoundOnce(clickSound);
    }

    public void PlayCoinSound()
    {
        PlayAnySoundOnce(coinSound);
    }

    public void PlayJumpSound()
    {
        PlayAnySoundOnce(jumpSound);
    }
}
