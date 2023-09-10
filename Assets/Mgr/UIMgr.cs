using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    int                 oLifes = 0;
    public GameObject   hpImage;
    public Sprite       life3Image;
    public Sprite       life2Image;
    public Sprite       life1Image;
    public Sprite       life0Image;
    public GameObject   mainImage;
    public GameObject   resetButton;
    public Sprite       gameOverSpr;
    public Sprite       gameClearSpr;
    public GameObject   inputPanel;
    GameObject          bar;

    void Start()
    {
        bar = GameObject.FindGameObjectWithTag("Bar");
        Invoke("InactiveImage", 1.0f);
        resetButton.SetActive(false);
    }

    void Update()
    {
        int GameState = bar.GetComponent<GameMgr>().getGameState();
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
                    bar.GetComponent<GameMgr>().add1Ball();
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
        if (bar != null)
        {
            int tLifes = bar.GetComponent<GameMgr>().getLifes();
            if (tLifes != oLifes)
            {
                oLifes = tLifes;
                if (oLifes <= 0)
                {
                    hpImage.GetComponent<Image>().sprite = life0Image;
                    resetButton.SetActive(true);
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
        else
        {
            SceneManager.LoadScene("Title");
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
    }

    public void GameClear()
    {
        mainImage.SetActive(true);
        mainImage.GetComponent<Image>().sprite = gameClearSpr;
        inputPanel.SetActive(false);
        Invoke("GoToTitle", 3.0f);
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
