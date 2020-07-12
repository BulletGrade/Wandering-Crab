using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameManager gameManager;

    void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameObject != null)
        {
            Destroy(gameObject, 2f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Friendly" && gameObject != null)
        {
            gameManager.StartCoroutine("Restart");
            Destroy(other.gameObject);
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }

        if (other.tag == "Enemy" && gameObject != null)
        {
            Destroy(other.gameObject);
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }

        if (other.gameObject.layer == 8)
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
