using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAllChildrenActive : MonoBehaviour
{
	// Use this for initialization
	void OnEnable ()
    {
        Transform[] childrenComponents = GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < childrenComponents.Length; i++)
        {
            childrenComponents[i].gameObject.SetActive(true);
        }
	}
}
