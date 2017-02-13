using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public void PlaySFX(string soundPath, float volume)
    {
        StartCoroutine(PlaySound(soundPath, volume));
    }

    IEnumerator PlaySound(string soundPath, float volume)
    {
        if (SaveFileManager.Instance.Sound)
        {
            AudioSource tempSound = Utils.CreateSFX(soundPath);
            tempSound.volume = volume;
            tempSound.Play();
            yield return new WaitWhile(() => tempSound.isPlaying);

            Destroy(tempSound.gameObject);
        }
    }
}
