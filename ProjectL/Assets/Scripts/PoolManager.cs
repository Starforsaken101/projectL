using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    private static string PATH_PREFIX = "Prefabs/";
    private List<string> _keys = new List<string>() { "p_cat", "p_wasp", "p_floorPlatform", "p_floorPlatform_half", "p_thinPlatform", "p_bigMushroomPlatform_spider",
                                                      "p_enemy1", "p_spinningSnail",
                                                      "p_level1_platform1", "p_level1_platform2", "p_level1_platform5",
                                                      "p_spiderPlatform_oneLeft", "p_spiderPlatform_oneRight", "p_spiderPlatform_oneMiddle", "p_spiderPlatform_two", "p_floorPlatform_half_spider",
                                                      "p_snailPlatform_oneLeft", "p_thinPlatform_snail",
                                                      "p_bigMushroomPlatform", "p_platformWithMushroom", "p_platformWithMushroomAndSnail",
                                                      "p_squareMushroomPlatform",
                                                      "p_thornTrap", "p_platformOneTrap", "p_platformSpiderTrapSpider", "p_platformSpiderTrap", "p_floorPlatform_half_trap"};

    Dictionary<string, Stack<GameObject>> _pool = new Dictionary<string, Stack<GameObject>>();

    void OnEnable()
    {
        Instantiate();
    }

    private void Instantiate()
    {
        for (int i = 0; i < _keys.Count; i++)
        {
            CreatePool(_keys[i]);
        }
    }

    private void CreatePool(string prefabKey)
    {
        Stack<GameObject> newStack = new Stack<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject gameObject = Utils.InstantiateGameObjectByPath(PATH_PREFIX + prefabKey);
            gameObject.SetActive(false);
            newStack.Push(gameObject);
        }

        _pool.Add(prefabKey, newStack);
    }

    public GameObject GetGameObject(string key)
    {
        if (!_pool.ContainsKey(key))
        {
            Debug.LogError("[PoolManager - GetGameObject] - Error: pool of key " + key + " does not exist");
            return null;
        }

        GameObject gameObject;
        Stack<GameObject> stack = _pool[key];
        if (stack.Count == 0)
        {
            gameObject = Utils.InstantiateGameObjectByPath(PATH_PREFIX + key);
            gameObject.name = key;
            return gameObject;
        }

        gameObject = stack.Pop();
        gameObject.SetActive(true);
        
        gameObject.name = key;
        return gameObject;
    }

    public void ReturnGameObject(string key, GameObject gameObject)
    {
        if (gameObject.transform.parent != null)
        {
            PrefabSpawner prefabSpawner = gameObject.transform.parent.GetComponent<PrefabSpawner>();
            if (prefabSpawner == null)
            {
                key = gameObject.transform.parent.name;
                gameObject = gameObject.transform.parent.gameObject;
            }
            else
            {
                key = prefabSpawner.transform.parent.name;
                gameObject = prefabSpawner.transform.parent.gameObject;
            }
        }

        if (!_pool.ContainsKey(key))
        {
            Debug.LogError("[PoolManager - ReturnGameObject] - Error: pool of key " + key + " does not exist");
            return;
        }

        // Destroy point containers
        PointContainer[] pointContainers = gameObject.GetComponentsInChildren<PointContainer>();
        if (pointContainers.Length > 0)
        {
            for (int i = 0; i < pointContainers.Length; i++)
            {
                GameObject.Destroy(pointContainers[i].gameObject);
            }
        }

        Stack<GameObject> stack = _pool[key];
        if (stack.Count == 3)
        {
            GameObject.Destroy(gameObject);
            return;
        }

        gameObject.SetActive(false);
        stack.Push(gameObject);
    }
}
