using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMusic : MonoBehaviour
{
    List<AudioSource> _music = new List<AudioSource>();
    // Start is called before the first frame update
    public void Start()
    {
        AudioSource[] allAudioSources = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
        _music.Add(allAudioSources[0]);

        Slider musicSlider = this.GetComponent<Slider>();
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            UpdateMusicVolume(musicSlider.value);
        }
        else
        {
            musicSlider.value = 0.1f;
            UpdateMusicVolume(musicSlider.value);
        }
    }

    public void UpdateMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("musicVolume", value);
        foreach(AudioSource m in _music)
        {
            m.volume = value;
        }
    }
}
