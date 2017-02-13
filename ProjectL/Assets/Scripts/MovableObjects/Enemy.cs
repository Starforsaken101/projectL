using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyDeathCollider _enemyDeathCollider;
    [SerializeField]
    private EnemyBounceCollider _enemyBounceCollider;

    protected virtual void OnEnable()
    {
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
        SoundManager.Instance.PlaySFX(Utils.SFX_PLAYER_DEATH_BY_ENEMY, 0.5f);
        GameController.Instance.CurrentTutorialState = TutorialState.DEATH_BY_SPIDER;
    }
    
    protected virtual void OnEnemyBounce()
    {
        SoundManager.Instance.PlaySFX(Utils.SFX_ENEMY_DIE, 0.75f);
        gameObject.SetActive(false);
    }
}
