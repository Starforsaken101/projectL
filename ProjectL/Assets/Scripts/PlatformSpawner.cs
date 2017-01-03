using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct DistanceBasedPatterns
    {
        public float distance;
        public List<PatternScriptableObject> patterns;
    }

    public List<DistanceBasedPatterns> patterns;

    private float _currentTime = 0;
    private Vector3 _startPosition = new Vector3(10.78f, 0, 0);

    void Start()
    {
        StartCoroutine(InitiatePatternSpawn());
    }

    private IEnumerator InitiatePatternSpawn()
    {
        PatternScriptableObject pattern;
        while (SpeedController.Instance.Speed > 0)
        {
            //PatternScriptableObject pattern = patterns[Random.Range(0, patterns.Count)];
            pattern = null;
            for (int i = patterns.Count - 1; i >= 0; i--)
            {
                if (StaticVariables.DISTANCE >= patterns[i].distance)
                {
                    pattern = patterns[i].patterns[Random.Range(0, patterns[i].patterns.Count)];
                    break;
                }
            }
            yield return StartCoroutine(SpawnPattern(pattern));
        }
    }

    private IEnumerator SpawnPattern(PatternScriptableObject pattern)
    {
        for (int i = 0; i < pattern.platforms.Count; i++)
        {
            yield return StartCoroutine(SpawnPlatformByKey(pattern.platforms[i]));

            if (!SpeedController.Instance.IsInitialized)
                SpeedController.Instance.Initialize();

            while (_currentTime < pattern.platforms[i].timeDelay)
            {
                _currentTime += SpeedController.Instance.GetDeltaTime(Time.deltaTime);
                yield return null;
            }
            _currentTime = 0;
        }
    }

    private IEnumerator SpawnPlatformByKey(PlatformData platformData)
    {
        GameObject platform = PoolManager.Instance.GetGameObject(platformData.platformID);
        MovableObject movableObject = platform.GetComponentInChildren<MovableObject>();

        if (platformData.platformAsset != null)
        {
            if (movableObject != null)
            {
                movableObject.SetPlatformSprite(platformData.platformAsset);
            }
        }
        else
        {
            movableObject.RestoreDefaultPlatformSprite();
        }

        platform.transform.position = new Vector3(_startPosition.x, platformData.y, _startPosition.z);
        yield return null;
    }
}
