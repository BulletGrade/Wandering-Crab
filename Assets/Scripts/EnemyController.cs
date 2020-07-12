using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isRunner;
    Animator enemyAnimation;
    public float speed;
    public float distance;
    GameManager gameManager;

    bool movingRight = true;

    public Transform groundCheck;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemyAnimation = GetComponent<Animator>();

        if (isRunner)
        {
            enemyAnimation.SetBool("isRunner", true);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.StartCoroutine("Restart");
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);

        if (!groundInfo.collider && movingRight)
        {
            movingRight = false;
            transform.eulerAngles = new Vector2(0, -180);
        }
        else if (!groundInfo && !movingRight)
        {
            movingRight = true;
            transform.eulerAngles = new Vector2(0, 0);
        }
    }
}
