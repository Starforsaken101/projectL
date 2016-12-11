using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public List<PatternScriptableObject> patterns;

    private Vector3 _startPosition = new Vector3(8.81f, 0, 0);
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1);

    void Start()
    {
        StartCoroutine(InitiatePatternSpawn());
    }

    private IEnumerator InitiatePatternSpawn()
    {
        while (true)
        {
            PatternScriptableObject pattern = patterns[Random.Range(0, patterns.Count)];
            yield return StartCoroutine(SpawnPattern(pattern));
        }
    }

    private IEnumerator SpawnPattern(PatternScriptableObject pattern)
    {
        for (int i = 0; i < pattern.platforms.Count; i++)
        {
            yield return StartCoroutine(SpawnPlatformByKey(pattern.platforms[i]));
            yield return _waitForSeconds;
        }
    }

    private IEnumerator SpawnPlatformByKey(PlatformData platformData)
    {
        GameObject platform = PoolManager.Instance.GetGameObject(platformData.platformID);
        platform.transform.position = new Vector3(_startPosition.x, platformData.y, _startPosition.z);
        yield return null;
    }
}
