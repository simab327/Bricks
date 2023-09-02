using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCnt : MonoBehaviour
{
    //public float speed = 3.0f;

    Vector2 velo;

    float axisH;
    float axisV;
    
    Rigidbody2D rbody;
    bool isMoving = false;

    //public static int hp = 3;
    //public static string gameState;

    GameObject SquareWR;
    GameObject SquareWL;
    GameObject CircleWR;
    GameObject CircleWL;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        //gameState = "playing";
        SquareWR = GameObject.Find("SquareWR");
        SquareWL = GameObject.Find("SquareWL");
        CircleWR = GameObject.Find("CircleWR");
        CircleWL = GameObject.Find("CircleWL");
        SquareWR.SetActive(false);
        SquareWL.SetActive(false);
        CircleWR.SetActive(false);
        CircleWL.SetActive(false);
    }

    void Update()
    {
        int BarLength = GameMgr.getBarLength();
        if (BarLength == 0)
        {
            SquareWR.SetActive(false);
            SquareWL.SetActive(false);
            CircleWR.SetActive(false);
            CircleWL.SetActive(false);
        }
        else
        {
            SquareWR.SetActive(true);
            SquareWL.SetActive(true);
            CircleWR.SetActive(true);
            CircleWL.SetActive(true);
        }

        int GameState = GameMgr.getGameState();
        switch (GameState)
        {
            case Constants.s_playing:
                if (isMoving == false)
                {
                    axisH = Input.GetAxisRaw("Horizontal");
                    axisV = Input.GetAxisRaw("Vertical");
                }
                axisV = 0;
                break;
            case Constants.s_gameclear:
                break;
            case Constants.s_gameover:
                break;
            case Constants.s_suspend:
                break;
            case Constants.s_resume:
                break;
            default:
                break;
        }
    }

    void FixedUpdate()
    {
        int GameState = GameMgr.getGameState();
        float barSpeed = GameMgr.getBarSpeed();
        switch (GameState)
        {
            case Constants.s_playing:
                if (GameState != Constants.s_playing)
                {
                    return;
                }
                velo = new Vector2(axisH, axisV) * barSpeed;
                rbody.velocity = velo;
                break;
            case Constants.s_gameclear:
                break;
            case Constants.s_gameover:
                break;
            case Constants.s_suspend:
                break;
            case Constants.s_resume:
                break;
            default:
                break;
        }
    }

    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

}
