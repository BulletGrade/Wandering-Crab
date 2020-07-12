using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject player;

    public IEnumerator Restart()
    {
        gameCamera.backgroundColor = Color.red;
        player.GetComponent<Rigidbody2D>().simulated = false;
        player.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

        IEnumerator Win()
    {
        gameCamera.backgroundColor = Color.green;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
