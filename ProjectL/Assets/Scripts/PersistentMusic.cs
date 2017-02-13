using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class PersistentMusic : MonoBehaviour
{
    private static PersistentMusic _instance;
    private AudioSource _audioListener;

    private bool _isMuted = false;

    void Awake()
    {
        _audioListener = GetComponent<AudioSource>();

        HandleMusic();
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (_isMuted != SaveFileManager.Instance.Music)
        {
            HandleMusic();
        }
    }

    private void HandleMusic()
    {
        _isMuted = SaveFileManager.Instance.Music;
        _audioListener.mute = !_isMuted;
    }
}
