using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCollider : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            PoolManager.Instance.ReturnGameObject(PoolManager.SMALL_PLATFORM, collision.gameObject);
        }
    }
}
