using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public float[] Direction = {-10, 10};
    float lastShot;

    void Update()
    {
        if (Time.time > lastShot + 10)
        {
            Spawner();
            lastShot = Time.time;
        }
    }

    void Spawner()
    {
        float randomDirection = Direction[Random.Range(0,1)];
        Instantiate(bullet, transform.parent.position + new Vector3(randomDirection, 0, 0), Quaternion.identity);
    }
}
