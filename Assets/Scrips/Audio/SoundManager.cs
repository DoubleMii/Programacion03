using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;


    public AudioSource audioSource;
    public AudioSource sfxSource;


    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        
    }


    void Start()
    {
        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        masterSlider.onValueChanged.AddListener(ChangeMasterVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);
    }


    public void PlayMusic(AudioClip Song)
    {
        if (audioSource.resource == Song && audioSource.isPlaying) 
        {
            return;
        }
        else if (audioSource.resource == Song)
        {
            audioSource.UnPause();
        }
        else
        {
            audioSource.resource = Song;
            audioSource.Play();
        }
            
    }
    public void PlaySfx(AudioClip Sfx)
    {
        sfxSource.resource = Sfx;
        sfxSource.Play();
    }


    public void StopMusic()
    { 
       audioSource.Pause();
    }

    public void ChangeMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume",
            Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20f);
    }

    public void ChangeMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume",
            Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20f);
    }

    public void ChangeSFXVolume(float volume)
    {
        audioMixer.SetFloat("SfxVolume",
            Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20f);
    }


    void Update()
    {
        
    }
}