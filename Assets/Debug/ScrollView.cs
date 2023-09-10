using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollView : MonoBehaviour
{
    public GameObject DebugText;
    public GameObject DebugWindow;
    public int logcnt = 0;

    private Text _logText;

    void Awake()
    {
        Application.logMessageReceived += LoggedCb;
        _logText = DebugText.GetComponent<Text>();
    }

    public void LoggedCb(string logstr, string stacktrace, LogType type)
    {
        if (logcnt > 200)
        {
            int index = _logText.text.IndexOf("\n");
            _logText.text = _logText.text.Substring(index + 1);
        }
        else
        {
            logcnt++;
        }

        _logText.text += logstr;
        _logText.text += "\n";

        DebugWindow.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
    }
}