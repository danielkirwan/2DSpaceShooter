using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSound : MonoBehaviour
{
    List<AudioSource> _sfx = new List<AudioSource>();

    // Start is called before the first frame update
    public void Start()
    {
        AudioSource[] allAudioSources = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
        for(int i = 1; i < allAudioSources.Length; i++)
        {
            _sfx.Add(allAudioSources[i]);
        }

        _sfx.Add(allAudioSources[1]);

        Slider sfxSlider = this.GetComponent<Slider>();
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
            UpdateSoundVolume(sfxSlider.value);
        }
        else
        {
            sfxSlider.value = 1;
            UpdateSoundVolume(1);
        }

    }

    public void UpdateSoundVolume(float value)
    {
        PlayerPrefs.SetFloat("sfxVolume", value);
        foreach(AudioSource s in _sfx)
        {
            s.volume = value;
        }
    }
}
