using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image blackScreen;
    public bool blackScreenOn = false;
  

    private float fadeSpeed = 2f;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
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

    //public void FadeToBlack(float fadeSpeed = 2f)
    //{
    //    blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
    //}

    //public void FadeFromBlack(float fadeSpeed = 2f) 
    //{
    //    Color bgcol = blackScreen.color;
    //    blackScreen.color = new Color(bgcol.r, bgcol.g, bgcol.b, Mathf.MoveTowards(bgcol.a, 0f, fadeSpeed * Time.deltaTime));
    //}

}
