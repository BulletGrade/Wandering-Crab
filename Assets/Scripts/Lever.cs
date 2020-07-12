using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject[] obstacles;
    Animator leverAnimation;
    bool isActivated;

    void Start()
    {
        leverAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isActivated)
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                Destroy(obstacles[i]);
            }
            leverAnimation.SetBool("Activated", true);
            isActivated = true;
        }
    }
}
