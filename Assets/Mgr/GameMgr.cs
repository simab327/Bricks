using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

static class Constants
{
    public const int    s_playing = 1;
    public const int    s_gameclear = 2;
    public const int    s_gameover = 3;
    public const int    s_suspend = 4;
    public const int    s_resume = 5;
}

public class GameMgr : MonoBehaviour
{
    int         GameState;

    int         hasBricks = 1;
    int         hasLifes = 3;
    int         addBalls = 0;
    int         delBalls = 0;
    int         genBalls = 0;

    int         addBarLen = 0;
    int         delBarLen = 0;
    float       ballSpd = 5.0f;
    float       barSpd = 3.0f;

    public GameObject   brickPrefab;
    public GameObject   ballPrefab;

    int[,] mapArray = new int[13, 10];

    void Start()
    {
        GameState = Constants.s_suspend;
        itemSet();
        //add1Ball();
    }

    void Update()
    {
        if (addBalls - genBalls >= 1)
        {
            genBall();
            ++genBalls;
        }

        switch (GameState)
        {
            case Constants.s_playing:
                if (hasLifes == 0)
                {
                    GameState = Constants.s_gameover;
                }
                if (hasBricks == 0)
                {
                    GameState = Constants.s_gameclear;
                }
                break;
            case Constants.s_gameclear:
                break;
            case Constants.s_gameover:
                break;
            case Constants.s_suspend:
                addBalls = 0;
                delBalls = 0;
                genBalls = 0;
                addBarLen = 0;
                delBarLen = 0;
                ballSpd = 5.0f;
                barSpd = 3.0f;
                break;
            case Constants.s_resume:
                GameState = Constants.s_playing;
                break;
            default:
                break;
        }
    }

    public void brickSet()
    {
        hasBricks = 0;
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 13; x++)
            {
                Quaternion r = Quaternion.Euler(0, 0, 0);
                Vector3 pos = transform.position;
                pos.x = -1.8f + 0.3f * x;
                pos.y = 3.0f - 0.2f * y;
                GameObject brickObj = Instantiate(brickPrefab, pos, r);
                ++hasBricks;
            }
        }
    }

    void genBall()
    {
        Quaternion r = Quaternion.Euler(0, 0, 0);
        Vector3 pos = transform.position;
        pos.x = 0;
        pos.y = 0;
        GameObject ballObj = Instantiate(ballPrefab, pos, r);
    }

    public int getGameState()
    {
        return GameState;
    }

    public void addBarSpeed()
    {
        if (barSpd <= 5.0f)
        {
            barSpd = barSpd + 0.5f;
        }
    }

    public float getBarSpeed()
    {
        return barSpd;
    }

    public void delBallSpeed()
    {
        if (ballSpd >= 3.0f)
        {
            ballSpd = ballSpd - 0.5f;
        }
    }

    public float getBallSpeed()
    {
        return ballSpd;
    }

    public void addbarLength()
    {
        ++addBarLen;
        Invoke("delBarLength", 10.0f);
    }

    public void delBarLength()
    {
        ++delBarLen;
    }

    public int getBarLength()
    {
        return addBarLen - delBarLen;
    }

    public void delLife()
    {
        --hasLifes;
        if (hasLifes == 0)
        {
            GameState = Constants.s_gameover;
        }
        else
        {
            GameState = Constants.s_suspend;
        }
    }

    public void addLife()
    {
        ++hasLifes;
    }

    public int getLifes()
    {
        return hasLifes;
    }

    public void delBall()
    {
        ++delBalls;
    }

    public void add1Ball()
    {
        ++addBalls;
        if (GameState == Constants.s_suspend)
        {
            GameState = Constants.s_resume;
        }
    }

    public void add10Ball()
    {
        addBalls += 10;
    }

    public int getBalls()
    {
        return addBalls - delBalls;
    }

    public void delBlock()
    {
        --hasBricks;
    }

    public void addBrick()
    {
        ++hasBricks;
    }

    public int getBricks()
    {
        return hasBricks;
    }

    public void itemSet()
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 13; x++)
            {
                mapArray[x, y] = 0;
            }
        }

        int i = 1;
        while (i < 10)
        {
            int rndx = Random.Range(0, 13);
            int rndy = Random.Range(0, 10);
            if (mapArray[rndx, rndy] == 0)
            {
                mapArray[rndx, rndy] = 1;
                i++;
            }
        }

        i = 1;
        while (i < 10)
        {
            int rndx = Random.Range(0, 13);
            int rndy = Random.Range(0, 10);
            if (mapArray[rndx, rndy] == 0)
            {
                mapArray[rndx, rndy] = 2;
                i++;
            }
        }

        i = 1;
        while (i < 10)
        {
            int rndx = Random.Range(0, 13);
            int rndy = Random.Range(0, 10);
            if (mapArray[rndx, rndy] == 0)
            {
                mapArray[rndx, rndy] = 3;
                i++;
            }
        }

        i = 1;
        while (i < 10)
        {
            int rndx = Random.Range(0, 13);
            int rndy = Random.Range(0, 10);
            if (mapArray[rndx, rndy] == 0)
            {
                mapArray[rndx, rndy] = 4;
                i++;
            }
        }

        i = 1;
        while (i < 10)
        {
            int rndx = Random.Range(0, 13);
            int rndy = Random.Range(0, 10);
            if (mapArray[rndx, rndy] == 0)
            {
                mapArray[rndx, rndy] = 5;
                i++;
            }
        }

        hasBricks = 0;
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 13; x++)
            {
                Quaternion r = Quaternion.Euler(0, 0, 0);
                Vector3 pos = transform.position;
                pos.x = -1.8f + 0.3f * x;
                pos.y = 3.0f - 0.2f * y;
                GameObject brickObj = Instantiate(brickPrefab, pos, r);
                BrickCnt bc = brickObj.GetComponent<BrickCnt>();
                bc.hasItemType = mapArray[x, y];
                ++hasBricks;
            }
        }
    }

}
