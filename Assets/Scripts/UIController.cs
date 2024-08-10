using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image blackScreen;
    public bool blackScreenOn = false;
  

    private float fadeSpeed = 1.5f;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        
        FadeControl();
    }

    public void FadeControl()
    {
        if (blackScreenOn)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
        }
        else if (!blackScreenOn)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
        }
    }


}
