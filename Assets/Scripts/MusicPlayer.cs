using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer _instance;

    public static MusicPlayer Instance { get { return _instance; } }

    [SerializeField]
    AudioMixerGroup mixerGroup;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        Init();
    }

    private void Init()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            float volume = PlayerPrefs.GetFloat("Volume");
            Debug.Log("Setting audio volume to " + volume);
            mixerGroup.audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        }
    }
}
