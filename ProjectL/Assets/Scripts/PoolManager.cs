using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PoolManager();
            }
            return _instance;
        }
    }

    private static string PATH_PREFIX = "Prefabs/";
    private List<string> _keys = new List<string>() { "p_smallGround", "p_cat", "p_projectile", "p_floorPlatform", "p_enemy1",
                                                       "p_level1_platform1", "p_level1_platform2", "p_level1_platform4", "p_level1_platform5"};

    Dictionary<string, Stack<GameObject>> _pool = new Dictionary<string, Stack<GameObject>>();

    public PoolManager()
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
            key = gameObject.transform.parent.name;
            gameObject = gameObject.transform.parent.gameObject;
        }

        if (!_pool.ContainsKey(key))
        {
            Debug.LogError("[PoolManager - ReturnGameObject] - Error: pool of key " + key + " does not exist");
            return;
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
