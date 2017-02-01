using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyDeathCollider _enemyDeathCollider;
    [SerializeField]
    private EnemyBounceCollider _enemyBounceCollider;

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
        gameObject.SetActive(false);
    }
}
