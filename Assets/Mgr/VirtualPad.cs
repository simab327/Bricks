using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VirtualPad : MonoBehaviour
{
    public float MaxLength = 70;
    public bool is4DPad = false;
    GameObject bar;
    Vector2 defPos;
    Vector2 downPos;
    
    void Start()
    {
        bar = GameObject.FindGameObjectWithTag("Bar");
        defPos = GetComponent<RectTransform>().localPosition;
    }

    void Update()
    {
    }

    public void PadDown()
    {
        downPos = Input.mousePosition;
    }

    public void PadDrag()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 newTabPos = mousePosition - downPos;
        if (is4DPad == false)
        {
            newTabPos.y = 0;
        }

        Vector2 axis = newTabPos.normalized;
        float len = Vector2.Distance(defPos, newTabPos);
        if (len > MaxLength)
        {
            newTabPos.x = axis.x * MaxLength;
            newTabPos.y = axis.y * MaxLength;
        }
        GetComponent<RectTransform>().localPosition = newTabPos;
        BarCnt barcnt = bar.GetComponent<BarCnt>();
        barcnt.SetAxis(axis.x, axis.y);
    }

    public void PadUp()
    {
        GetComponent<RectTransform>().localPosition = defPos;
        BarCnt barcnt = bar.GetComponent<BarCnt>();
        barcnt.SetAxis(0, 0);
    }

    public void Attack()
    {
        int GameState = bar.GetComponent<GameMgr>().getGameState();
        switch (GameState)
        {
            case Constants.s_playing:
                break;
            case Constants.s_gameclear:
                break;
            case Constants.s_gameover:
                break;
            case Constants.s_suspend:
                bar.GetComponent<GameMgr>().add1Ball();
                break;
            case Constants.s_resume:
                break;
            default:
                break;
        }
    }

}
