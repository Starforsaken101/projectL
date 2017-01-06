using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityIntEvent : UnityEvent<int> { }

[System.Serializable]
public class PopupEvent : UnityEvent<Popups> { }

[System.Serializable]
public class PowerupEvent : UnityEvent<Powerup> { }

public static class Utils
{
    public static GameObject InstantiateGameObjectByPath(string path)
    {
        Object prefab = Resources.Load(path);
        return (GameObject)GameObject.Instantiate(prefab);
    }
}
