﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.Instance.CurrentTutorialState = TutorialState.DEATH_BY_TRAP;
            collision.GetComponent<PlayerController>().OnDeath();
        }
    }
}
