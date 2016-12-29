using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pattern", menuName ="Pattern", order = 1)]
public class PatternScriptableObject : ScriptableObject
{
    public float timeDelay = 1;
    public float timeBeforeNext = 0;
    public List<PlatformData> platforms;
}

[System.Serializable]
public class PlatformData
{
    public string platformID;
    public float y;
}
