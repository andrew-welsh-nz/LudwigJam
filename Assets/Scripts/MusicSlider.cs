using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField]
    AudioMixerGroup mixerGroup;

    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        if(PlayerPrefs.HasKey("Volume"))
        {
            float volume = PlayerPrefs.GetFloat("Volume");
            slider.value = volume;
        }
    }

    public void UpdateVolume(float _newVolume)
    {
        mixerGroup.audioMixer.SetFloat("Volume", Mathf.Log10(_newVolume) * 20);
        PlayerPrefs.SetFloat("Volume", _newVolume);
    }
}
