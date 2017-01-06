using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCat : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _finalDestination;

    void OnEnable()
    {
        _isMoving = false;
        transform.localPosition = Vector3.zero;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.Instance.AddPoints(1);
            gameObject.SetActive(false);
        }
    }

    public void MoveTowardsPlayer(GameObject player)
    {
        _isMoving = true;
        _finalDestination = player.transform.position;
    }

    void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _finalDestination, Time.deltaTime * 7);
        }
    }
}
