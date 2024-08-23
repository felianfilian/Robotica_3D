using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public GameObject effectPlayerDeath;

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
        if (!PlayerController.instance.isKnocking)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Instantiate(effectPlayerDeath, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
            else
            {
                PlayerController.instance.KnockBack();
            }
            UIController.instance.UpdateUI();
        }
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
