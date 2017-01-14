using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PrefabSpawner))]
public class PrefabSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PrefabSpawner prefabSpawner = (PrefabSpawner)target;
        if (GUILayout.Button("Spawn Prefab"))
        {
            prefabSpawner.SpawnPrefab();
        }
    }
}
