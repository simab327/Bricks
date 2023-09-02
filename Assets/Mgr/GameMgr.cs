using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const int s_playing = 1;
    public const int s_gameclear = 2;
    public const int s_gameover = 3;
    public const int s_suspend = 4;
    public const int s_resume = 5;
}

public class GameMgr : MonoBehaviour
{
    static int GameState;

    static int hasBlocks = 1;
    static int hasLifes = 3;
    static int addBalls = 0;
    static int delBalls = 0;
    static int genBalls = 0;

    static int addBarLen = 0;
    static int delBarLen = 0;
    static float ballSpd = 5.0f;
    static float barSpd = 3.0f;

    public GameObject blockPrefab;
    public GameObject ballPrefab;

    public static int[,] mapArray = new int[13, 10];

    void Start()
    {
        GameState = Constants.s_playing;
        itemSet();
        add1Ball();
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
                if (hasBlocks == 0)
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
        //Debug.Log("GameMgr: GameState " + GameState);
        //Debug.Log("GameMgr: hasBlocks " + hasBlocks);
        //Debug.Log("GameMgr: hasLifes " + hasLifes);
        //Debug.Log("GameMgr: addBalls " + addBalls);
        //Debug.Log("GameMgr: delBalls " + delBalls);
        //Debug.Log("GameMgr: genBalls " + genBalls);
        Debug.Log("GameMgr: addBarLen " + addBarLen);
        Debug.Log("GameMgr: delBarLen " + delBarLen);
        //Debug.Log("GameMgr: ballSpd " + ballSpd);
        //Debug.Log("GameMgr: barSpd " + barSpd);
    }

    public void blockSet()
    {
        hasBlocks = 0;
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 13; x++)
            {
                Quaternion r = Quaternion.Euler(0, 0, 0);
                Vector3 pos = transform.position;
                pos.x = -1.8f + 0.3f * x;
                pos.y = 3.0f - 0.2f * y;
                GameObject blockObj = Instantiate(blockPrefab, pos, r);
                ++hasBlocks;
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

    public static int getGameState()
    {
        return GameState;
    }

    public static void addBarSpeed()
    {
        if (barSpd <= 5.0f)
        {
            barSpd = barSpd + 0.5f;
        }
    }

    public static float getBarSpeed()
    {
        return barSpd;
    }

    public static void delBallSpeed()
    {
        if (ballSpd >= 3.0f)
        {
            ballSpd = ballSpd - 0.5f;
        }
    }

    public static float getBallSpeed()
    {
        return ballSpd;
    }

    public static void addbarLength()
    {
        ++addBarLen;
        //MonoBehaviour.Invoke("delBarLen", 3.0f);
    }

    public static void delBarLength()
    {
        ++delBarLen;
    }

    public static int getBarLength()
    {
        return addBarLen - delBarLen;
    }

    public static void delLife()
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

    public static void addLife()
    {
        ++hasLifes;
    }

    public static int getLifes()
    {
        return hasLifes;
    }

    public static void delBall()
    {
        ++delBalls;
    }

    public static void add1Ball()
    {
        ++addBalls;
        if (GameState == Constants.s_suspend)
        {
            GameState = Constants.s_resume;
        }
    }

    public static void add10Ball()
    {
        addBalls += 10;
    }

    public static int getBalls()
    {
        return addBalls - delBalls;
    }

    public static void delBlock()
    {
        --hasBlocks;
    }

    public static void addBlock()
    {
        ++hasBlocks;
    }

    public static int getBlocks()
    {
        return hasBlocks;
    }

    //public static void SaveItem()
    //{
    //    PlayerPrefs.SetInt("Keys", hasKeys);
    //    PlayerPrefs.SetInt("Arrows", hasArrows);
    //}

    //public static int getArray(int x, int y)
    //{
    //    return mapArray[x, y];
    //}

    //public static void delArrayBlock(int x, int y)
    //{
    //    mapArray[x, y] -= Constants.cBlock;
    //    //Debug.Log("ItemKeeper: x " + x + ", y " + y);
    //}

    //public static void setArrayBomb(int x, int y)
    //{
    //    mapArray[x, y] += Constants.cBomb;
    //    //Debug.Log("ItemKeeper: x " + x + ", y " + y);
    //}

    //public static void delArrayBomb(int x, int y)
    //{
    //    mapArray[x, y] -= Constants.cBomb;
    //    //Debug.Log("ItemKeeper: x " + x + ", y " + y);
    //}

    public void itemSet()
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 13; x++)
            {
                mapArray[x, y] = 0;
            }
        }

        //add SubBall
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

        hasBlocks = 0;
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 13; x++)
            {
                Quaternion r = Quaternion.Euler(0, 0, 0);
                Vector3 pos = transform.position;
                pos.x = -1.8f + 0.3f * x;
                pos.y = 3.0f - 0.2f * y;
                GameObject blockObj = Instantiate(blockPrefab, pos, r);
                BlockCnt bc = blockObj.GetComponent<BlockCnt>();
                bc.hasItemType = mapArray[x, y];
                ++hasBlocks;
            }
        }
    }

}
