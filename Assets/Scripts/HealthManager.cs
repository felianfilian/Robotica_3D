using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int maxHealth = 6;

    private int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }


    public void GetDamager(int amount)
    {
        currentHealth -= amount;
    }

    public void GetHealth(int amount)
    {
        currentHealth += amount;
    }
}
