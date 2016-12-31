using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public List<PatternScriptableObject> patterns;

    private Vector3 _startPosition = new Vector3(8f, 0, 0);
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

            if (StaticVariables.DISTANCE >= pattern.distance && (pattern.disappearDistance < 0 || StaticVariables.DISTANCE <= pattern.disappearDistance))
            {
                yield return StartCoroutine(SpawnPattern(pattern));
            }
            yield return null;
        }
    }

    private IEnumerator SpawnPattern(PatternScriptableObject pattern)
    {
        for (int i = 0; i < pattern.platforms.Count; i++)
        {
            yield return StartCoroutine(SpawnPlatformByKey(pattern.platforms[i]));
            yield return new WaitForSeconds(pattern.platforms[i].timeDelay);
        }
    }

    private IEnumerator SpawnPlatformByKey(PlatformData platformData)
    {
        GameObject platform = PoolManager.Instance.GetGameObject(platformData.platformID);
        platform.transform.position = new Vector3(_startPosition.x, platformData.y, _startPosition.z);
        yield return null;
    }
}
