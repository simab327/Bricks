using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCnt : MonoBehaviour
{
    public float deleteTime = 1.0f;
    Vector2     velo;
    Rigidbody2D rbody;
    GameObject  player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rbody = GetComponent<Rigidbody2D>();
        velo = new Vector2(1, -1);
        rbody.velocity = velo;
    }

    void Update()
    {
        float maxBallSpeed = player.GetComponent<GameMgr>().getBallSpeed();
        float clampedSpeed = Mathf.Clamp(velo.magnitude, 3, maxBallSpeed);
        velo = rbody.velocity;
        rbody.velocity = velo.normalized * clampedSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Ball: OnCollisionEnter2D");
        if (collision.gameObject.tag == "Hall")
        {
            GetDamage(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }

    void GetDamage(GameObject Hall)
    {
        int GameState = player.GetComponent<GameMgr>().getGameState();
        if (GameState == Constants.s_playing)
        {
            rbody.velocity = new Vector2(0, 0);
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject, deleteTime);

            player.GetComponent<GameMgr>().delBall();
            int SubBalls = player.GetComponent<GameMgr>().getBalls();
            if (SubBalls == 0)
            {
                player.GetComponent<GameMgr>().delLife();
            }
        }
    }

}
