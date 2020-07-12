using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinFlag : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            FindObjectOfType<BulletSpawner>().enabled = false;
            gameManager.StartCoroutine("Win");
        }
    }
}
