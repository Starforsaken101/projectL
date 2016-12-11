using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static GameObject InstantiateGameObjectByPath(string path)
    {
        Object prefab = Resources.Load(path);
        return (GameObject)GameObject.Instantiate(prefab);
    }
}
