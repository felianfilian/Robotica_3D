using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int maxHealth = 6;
    public int currentHealth;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateUI();
    }


    public void GetDamage(int amount)
    {
        currentHealth -= amount;
        UIController.instance.UpdateUI();
    }

    public void GetHealth(int amount)
    {
        currentHealth += amount;
        UIController.instance.UpdateUI();
    }
}
