using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyDeathCollider _enemyDeathCollider;
    [SerializeField]
    private EnemyBounceCollider _enemyBounceCollider;
    [SerializeField]
    private AudioSource _sfxDeath;

    void OnEnable()
    {
        if (_enemyBounceCollider == null)
        {
            int i = 0;
        }
        _enemyBounceCollider.OnBounce.AddListener(OnEnemyBounce);
        _enemyDeathCollider.OnDeath.AddListener(OnPlayerDeath);
    }

    void OnDisable()
    {
        _enemyBounceCollider.OnBounce.RemoveListener(OnEnemyBounce);
        _enemyDeathCollider.OnDeath.RemoveListener(OnPlayerDeath);
    }

    protected virtual void OnPlayerDeath()
    {
        GameController.Instance.CurrentTutorialState = TutorialState.DEATH_BY_SPIDER;
    }
    
    protected virtual void OnEnemyBounce()
    {
        StartCoroutine(PlaySound());
        gameObject.SetActive(false);
    }

    private IEnumerator PlaySound()
    {
        AudioSource tempSound = Utils.CreateSFX(Utils.SFX_ENEMY_DIE);
        tempSound.volume = 1.0f;
        tempSound.Play();
        yield return new WaitWhile(() => tempSound.isPlaying);

        Destroy(tempSound);
    }
}
