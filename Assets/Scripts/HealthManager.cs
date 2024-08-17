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
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("death");
            Instantiate(effectPlayerDeath,transform.position, Quaternion.identity);
            //GameManager.instance.Respawn();
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
