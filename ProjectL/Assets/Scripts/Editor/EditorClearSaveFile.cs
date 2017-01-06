using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorClearSaveFile
{
    [MenuItem("Tools/Clear SaveFile")]
    private static void ClearSaveFile()
    {
        PlayerPrefs.DeleteAll();
    }
}
