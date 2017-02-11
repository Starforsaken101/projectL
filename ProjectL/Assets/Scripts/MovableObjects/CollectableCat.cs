using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCat : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _finalDestination;
    private AudioSource _sfxCollect;

    void OnEnable()
    {
        _sfxCollect = GetComponent<AudioSource>();
        _isMoving = false;
        transform.localPosition = Vector3.zero;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(PlaySound());
            ScoreManager.Instance.AddPoints(1);
            gameObject.SetActive(false);
        }
    }

    IEnumerator PlaySound()
    {
        AudioSource tempSound = Utils.CreateSFX(Utils.SFX_COLLECT_TEACUP);
        tempSound.volume = 0.4f;
        tempSound.Play();
        yield return new WaitWhile(() => tempSound.isPlaying);
        Destroy(tempSound);
    }

    public void MoveTowardsPlayer(GameObject player)
    {
        _isMoving = true;
        _finalDestination = player.transform.position;
    }

    void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _finalDestination, Time.deltaTime * 7);
        }
    }
}
