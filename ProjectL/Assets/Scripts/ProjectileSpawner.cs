using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField]
    private float _chanceToSpawn = 0.01f;

    private float _currentTime = 0;
    private const float SPAWN_TIMER = 20;

    // Divide by 100 for precision in the random
    private const float MAX_Y = 280;
    private const float MIN_Y = -280;

    [System.Serializable]
    public struct DistanceBasedProjectiles
    {
        public float distance;
        public List<GameObject> projectiles;
    }

    public List<DistanceBasedProjectiles> projectiles;
    private Stack<Projectile> _activeProjectiles = new Stack<Projectile>();

    void Start()
    {
        StartCoroutine(InitiateProjectileSpawn());
    }

    private void OnProjectileDespawn()
    {
        if (_activeProjectiles.Count > 0)
        {
            _activeProjectiles.Pop();
        }

        if (_activeProjectiles.Count == 0 && _currentTime <= 0)
        {
            _currentTime = SPAWN_TIMER;
        }
    }

    private IEnumerator InitiateProjectileSpawn()
    {
        while (SpeedController.Instance.Speed > 0)
        {
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                if (DistanceController.Instance.Distance >= projectiles[i].distance)
                {
                    if (_activeProjectiles.Count > 0)
                    {
                        break;
                    }

                    if (_currentTime > 0)
                    {
                        _currentTime -= Time.deltaTime;
                        break;
                    }

                    float random = (float) Random.Range(0, 100) / 100;

                    if (random < _chanceToSpawn)
                    {
                        for (int j = 0; j < projectiles[i].projectiles.Count; j++)
                        {
                            yield return SpawnProjectileByKey(projectiles[i].projectiles[j]);
                        }
                    }
                    break;
                }
            }
            yield return null;
        }
    }

    private IEnumerator SpawnProjectileByKey(GameObject gameObject)
    {
        GameObject go = PoolManager.Instance.GetGameObject(gameObject.name);
        Projectile projectile = go.GetComponent<Projectile>();
        projectile.transform.position = new Vector3(projectile.transform.position.x, (float)Random.Range(MIN_Y, MAX_Y) / 100, projectile.transform.position.z);
        projectile.OnDespawn.AddListener(OnProjectileDespawn);

        _activeProjectiles.Push(projectile);
        yield return null;
    }
}
