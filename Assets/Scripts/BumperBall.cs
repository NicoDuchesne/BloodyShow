using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBall : MonoBehaviour
{
    public Vector2 puissance = new Vector2(0, 10f);
    public float bumpTime;
    private Rigidbody2D rb;


    void OnTriggerEnter2D(Collider2D ball)
    {
        if (ball.tag == "Player")
        {
            rb = ball.GetComponent<Rigidbody2D>();
            rb.velocity = puissance;
            ball.GetComponent<MovementBall>().enabled = false;
            StartCoroutine(bumping(ball.gameObject));
        }
    }

    IEnumerator bumping(GameObject player)
    {
        yield return new WaitForSeconds(bumpTime);
        player.GetComponent<MovementBall>().enabled = true;
    }
}
