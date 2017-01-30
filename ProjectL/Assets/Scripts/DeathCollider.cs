using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameController.Instance.CurrentTutorialState = TutorialState.DEATH_BY_FALL;
            collider.GetComponent<PlayerController>().OnDeath();
        }
    }
}
