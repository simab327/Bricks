using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Toggle : MonoBehaviour
{
    public GameObject DebugWindow;

    public void OnValueChanged(bool val)
    {
        DebugWindow.SetActive(val);
    }
}