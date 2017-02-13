using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    private Button _btnMusicOn;
    [SerializeField]
    private Button _btnMusicOff;
    [SerializeField]
    private Button _btnSoundOn;
    [SerializeField]
    private Button _btnSoundOff;

    void OnEnable()
    {
        UpdateButtonStates();
    }

    public void ToggleMusic(bool musicOn)
    {
        SaveFileManager.Instance.Music = musicOn;
        UpdateButtonStates();
    }

    public void ToggleSound(bool soundOn)
    {
        SaveFileManager.Instance.Sound = soundOn;
        UpdateButtonStates();
    }

    private void UpdateButtonStates()
    {
        if (SaveFileManager.Instance.Sound)
        {
            _btnSoundOff.interactable = true;
            _btnSoundOn.interactable = false;
        }
        else
        {
            _btnSoundOff.interactable = false;
            _btnSoundOn.interactable = true;
        }

        if (SaveFileManager.Instance.Music)
        {
            _btnMusicOff.interactable = true;
            _btnMusicOn.interactable = false;
        }
        else
        {
            _btnMusicOff.interactable = false;
            _btnMusicOn.interactable = true;
        }
    }
}
