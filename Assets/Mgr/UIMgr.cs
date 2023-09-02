using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    int oLifes = 0;
    public GameObject hpImage;
    public Sprite life3Image;
    public Sprite life2Image;
    public Sprite life1Image;
    public Sprite life0Image;
    public GameObject mainImage;
    public GameObject resetButton;
    public Sprite gameOverSpr;
    public Sprite gameClearSpr;
    public GameObject inputPanel;

    void Start()
    {
        UpdateHP();
        Invoke("InactiveImage", 1.0f);
        resetButton.SetActive(false);
    }

    void Update()
    {
        int GameState = GameMgr.getGameState();
        switch (GameState)
        {
            case Constants.s_playing:
                break;
            case Constants.s_gameclear:
                GameClear();
                break;
            case Constants.s_gameover:
                GameOver();
                break;
            case Constants.s_suspend:
                if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Fire3"))
                {
                    GameMgr.add1Ball();
                }
                else if (Input.GetButtonDown("Cancel"))
                {
                    SceneManager.LoadScene("Title");
                }
                break;
            case Constants.s_resume:
                break;
            default:
                break;
        }
        UpdateHP();
    }

    void UpdateHP()
    {
        int tLifes;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            tLifes = GameMgr.getLifes();
            if (tLifes != oLifes)
            {
                oLifes = tLifes;
                if (oLifes <= 0)
                {
                    hpImage.GetComponent<Image>().sprite = life0Image;
                    resetButton.SetActive(true);
                    //GameOver();
                }
                else if (oLifes == 1)
                {
                    hpImage.GetComponent<Image>().sprite = life1Image;
                }
                else if (oLifes == 2)
                {
                    hpImage.GetComponent<Image>().sprite = life2Image;
                }
                else
                {
                    hpImage.GetComponent<Image>().sprite = life3Image;
                }
            }
        }
    }

    void InactiveImage()
    {
        mainImage.SetActive(false);
    }

    public void GameOver()
    {
        mainImage.SetActive(true);
        mainImage.GetComponent<Image>().sprite = gameOverSpr;
        inputPanel.SetActive(false);
        //GameMgr.gameState = "gameover";
    }

    public void GameClear()
    {
        mainImage.SetActive(true);
        mainImage.GetComponent<Image>().sprite = gameClearSpr;
        inputPanel.SetActive(false);
        //GameMgr.gameState = "gameclear";
        Invoke("GoToTitle", 3.0f);
    }

    void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
