using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsSound : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sonSlider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }

        if (PlayerPrefs.HasKey("SonVolume"))
        {
            LoadSonVolume();
        }
        else
        {
            SetSonVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
    ////
    public void SetSonVolume()
    {
        float volumeSon = sonSlider.value;
        myMixer.SetFloat("Son", Mathf.Log10(volumeSon) * 20);
        PlayerPrefs.SetFloat("SonVolume", volumeSon);
    }

    private void LoadSonVolume()
    {
        sonSlider.value = PlayerPrefs.GetFloat("SonVolume");
    }

}
