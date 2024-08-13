using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public TMP_Text txtHealth;
    public Image blackScreen;
    public Image imgHealthHolder;
    public Sprite[] imgHealth;
    public bool blackScreenOn = false;
  

    private float fadeSpeed = 1.5f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateUI();
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

    public void UpdateUI()
    {
        int currentHealth = HealthManager.instance.currentHealth;
        txtHealth.text = currentHealth.ToString();
        UpdateHealthImg(currentHealth-1);
    }

    public void UpdateHealthImg(int index)
    {
        if(index >= imgHealth.Length)
        {
            index = imgHealth.Length - 1;
        } else if(index <= 0)
        {
            index = 0;
        }
        imgHealthHolder.sprite = imgHealth[index];

    }


}
