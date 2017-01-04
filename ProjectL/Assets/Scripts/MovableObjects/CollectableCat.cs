using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCat : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.Instance.AddPoints(1);
            gameObject.SetActive(false);
        }
    }
}
