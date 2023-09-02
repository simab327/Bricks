using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCnt : MonoBehaviour
{
    public float deleteTime = 1.0f;
    Vector2 velo;
    Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        velo = new Vector2(1, -1);
        rbody.velocity = velo;
    }

    void Update()
    {
        velo = rbody.velocity;
        float maxBallSpeed = GameMgr.getBallSpeed();
        float clampedSpeed = Mathf.Clamp(velo.magnitude, 3, maxBallSpeed);
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
        int GameState = GameMgr.getGameState();
        if (GameState == Constants.s_playing)
        {
            rbody.velocity = new Vector2(0, 0);
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject, deleteTime);

            GameMgr.delBall();
            int SubBalls = GameMgr.getBalls();
            if (SubBalls == 0)
            {
                GameMgr.delLife();
            }
        }
    }

}
