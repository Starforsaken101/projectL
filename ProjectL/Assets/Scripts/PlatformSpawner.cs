using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public List<PatternScriptableObject> patterns;

    private Vector3 _startPosition = new Vector3(8.81f, 0, 0);
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);

    void Start()
    {
        StartCoroutine(InitiatePatternSpawn());
    }

    private IEnumerator InitiatePatternSpawn()
    {
        while (SpeedController.Instance.Speed > 0)
        {
            PatternScriptableObject pattern = patterns[Random.Range(0, patterns.Count)];

            if (StaticVariables.DISTANCE >= pattern.distance)
            {
                yield return StartCoroutine(SpawnPattern(pattern));
            }
            yield return null;
        }
    }

    private IEnumerator SpawnPattern(PatternScriptableObject pattern)
    {
        _waitForSeconds = new WaitForSeconds(pattern.timeDelay);
        for (int i = 0; i < pattern.platforms.Count; i++)
        {
            yield return StartCoroutine(SpawnPlatformByKey(pattern.platforms[i]));
            yield return _waitForSeconds;
        }
        yield return new WaitForSeconds(pattern.timeBeforeNext);
    }

    private IEnumerator SpawnPlatformByKey(PlatformData platformData)
    {
        GameObject platform = PoolManager.Instance.GetGameObject(platformData.platformID);
        platform.transform.position = new Vector3(_startPosition.x, platformData.y, _startPosition.z);
        yield return null;
    }
}
