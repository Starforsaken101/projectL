using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAllChildrenActive : MonoBehaviour
{
	// Use this for initialization
	void OnEnable ()
    {
	    foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
	}
}
