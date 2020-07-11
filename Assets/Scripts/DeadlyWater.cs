using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadlyWater : MonoBehaviour
{
    public Camera gameCamera;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            StartCoroutine("Restart");
        }
    }

    IEnumerator Restart()
    {
        gameCamera.backgroundColor = Color.red;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
