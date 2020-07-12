using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyWater : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            gameManager.StartCoroutine("Restart");
        }
    }
}
