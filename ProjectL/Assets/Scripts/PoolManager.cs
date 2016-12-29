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
    public static string SMALL_PLATFORM = "p_smallGround";
    public static string CAT = "p_cat";
    public static string PROJECTILE = "p_projectile";

    Dictionary<string, Stack<GameObject>> _pool = new Dictionary<string, Stack<GameObject>>();

    public PoolManager()
    {
        Instantiate();
    }

    private void Instantiate()
    {
        // Small Platforms
        Stack<GameObject> smallPlatforms = new Stack<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject gameObject = Utils.InstantiateGameObjectByPath(PATH_PREFIX + SMALL_PLATFORM);
            gameObject.SetActive(false);
            smallPlatforms.Push(gameObject);
        }

        _pool.Add(SMALL_PLATFORM, smallPlatforms);

        // Cats
        Stack<GameObject> cats = new Stack<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject gameObject = Utils.InstantiateGameObjectByPath(PATH_PREFIX + CAT);
            gameObject.SetActive(false);
            cats.Push(gameObject);
        }

        _pool.Add(CAT, cats);

        // Projectiles
        Stack<GameObject> projectiles = new Stack<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject gameObject = Utils.InstantiateGameObjectByPath(PATH_PREFIX + PROJECTILE);
            gameObject.SetActive(false);
            projectiles.Push(gameObject);
        }

        _pool.Add(PROJECTILE, projectiles);
    }

    public GameObject GetGameObject(string key)
    {
        if (_pool[key] == null)
        {
            Debug.LogError("[PoolManager - GetGameObject] - Error: pool of key " + key + " does not exist");
            return null;
        }

        Stack<GameObject> stack = _pool[key];
        if (stack.Count == 0)
        {
            return Utils.InstantiateGameObjectByPath(PATH_PREFIX + key);
        }

        GameObject gameObject = stack.Pop();
        gameObject.SetActive(true);
        return gameObject;
    }

    public void ReturnGameObject(string key, GameObject gameObject)
    {
        if (_pool[key] == null)
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
