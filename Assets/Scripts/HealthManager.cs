using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int maxHealth = 5;
    public int currentHealth;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        FullHealth();      
    }


    public void GetDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameManager.instance.Respawn();
        }
        UIController.instance.UpdateUI();
    }

    public void GetHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) 
        { 
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateUI();
    }

    public void FullHealth()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateUI();
    }
}
