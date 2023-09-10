using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMgr : MonoBehaviour
{
    public GameObject startButton;
    public GameObject continueButton;
    public string firstSceneName;

    void Start()
    {
        continueButton.GetComponent<Button>().interactable = false;
    }

    void Update()
    {
        if ((Input.GetButtonDown("Fire3")))
        {
            StartButtonClicked();
        }
        else if ((Input.GetButtonDown("Fire2")) && continueButton.GetComponent<Button>().interactable)
        {
            ContinueButtonClicked();
        }
    }

    public void StartButtonClicked()
    {
        SceneManager.LoadScene(firstSceneName);
    }

    public void ContinueButtonClicked()
    {
    }
}

