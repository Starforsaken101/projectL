using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : MonoBehaviour
{
    protected void ClosePopup()
    {
        GameObject.Destroy(gameObject);
    }
}
