using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image blackScreen;

    private void Awake()
    {
        instance = this;
    }

    public void FadeToBlack()
    {

    }

    public void FadeFromBlack() 
    {
    }

}
