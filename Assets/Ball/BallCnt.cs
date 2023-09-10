using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCnt : MonoBehaviour
{
    public float deleteTime = 1.0f;
    Vector2     velo;
    Rigidbody2D rbody;
    GameObject  bar;

    void Start()
    {
        bar = GameObject.FindGameObjectWithTag("Bar");
        rbody = GetComponent<Rigidbody2D>();
        velo = new Vector2(1, -1);
        rbody.velocity = velo;
    }

    void Update()
    {
        float maxBallSpeed = bar.GetComponent<GameMgr>().getBallSpeed();
        float clampedSpeed = Mathf.Clamp(velo.magnitude, 3, maxBallSpeed);
        velo = rbody.velocity;
        rbody.velocity = velo.normalized * clampedSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        int GameState = bar.GetComponent<GameMgr>().getGameState();
        if (GameState == Constants.s_playing)
        {
            rbody.velocity = new Vector2(0, 0);
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject, deleteTime);

            bar.GetComponent<GameMgr>().delBall();
            int SubBalls = bar.GetComponent<GameMgr>().getBalls();
            if (SubBalls == 0)
            {
                bar.GetComponent<GameMgr>().delLife();
            }
        }
    }

}
