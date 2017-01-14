using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField]
    private string _path;

    void OnEnable()
    {
        SpawnPrefab();
    }

    public void SpawnPrefab()
    {
        DeleteChildren();

        if (string.IsNullOrEmpty(_path))
        {
            return;
        }

        GameObject go = Utils.InstantiateGameObjectByPath(_path);
        if (go != null)
        {
            go.transform.SetParent(this.transform, false);
        }
    }

    private void DeleteChildren()
    {
        var children = new List<GameObject>();
        foreach (Transform child in transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
    }
}
