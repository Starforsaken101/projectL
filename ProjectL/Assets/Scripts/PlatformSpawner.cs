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
    private Vector3 _startPosition = new Vector3(10.78f, 0, -2.72f);

    private int _lastIndex = -1;
    private int[] validChoices;

    void Start()
    {
        StartCoroutine(InitiatePatternSpawn());
    }

    private IEnumerator InitiatePatternSpawn()
    {
        PatternScriptableObject pattern;
        while (SpeedController.Instance.Speed > 0)
        {
            pattern = null;
            for (int i = patterns.Count - 1; i >= 0; i--)
            {
                if (DistanceController.Instance.Distance >= patterns[i].distance)
                {
                    FillValidChoices(patterns[i].patterns.Count);
                    _lastIndex = validChoices[Random.Range(0, validChoices.Length)];
                    //pattern = patterns[i].patterns[Random.Range(0, patterns[i].patterns.Count)];
                    pattern = patterns[i].patterns[_lastIndex];
                    break;
                }
            }
            yield return StartCoroutine(SpawnPattern(pattern));
        }
    }

    private void FillValidChoices(int count)
    {
        if (count > 1 && _lastIndex >= 0)
        {
            validChoices = new int[count - 1];
        }
        else
        {
            validChoices = new int[count];
        }

        int j = 0;
        for (int i = 0; i < count; i++)
        {
            if (i != _lastIndex)
            {
                validChoices[j] = i;
                j++;
            }
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

        if (!string.IsNullOrEmpty(platformData.pointObjectID))
        {
            GameObject pointGO = Utils.InstantiateGameObjectByPath(platformData.pointObjectID);
            pointGO.transform.SetParent(platform.transform);
            pointGO.transform.localPosition = new Vector3(platformData.pointStartPosition.x,
                                                          platformData.pointStartPosition.y,
                                                          -2f);
        }
        yield return null;
    }
}
