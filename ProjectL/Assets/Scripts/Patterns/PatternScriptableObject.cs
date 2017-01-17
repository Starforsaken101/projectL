using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pattern", menuName ="Pattern", order = 1)]
public class PatternScriptableObject : ScriptableObject
{
    public List<PlatformData> platforms;
}

[System.Serializable]
public class PlatformData
{
    public string platformID;
    public float y;
    public float timeDelay = 1;
    public Sprite platformAsset;
    public string pointObjectID;
    public Vector2 pointStartPosition;
}
