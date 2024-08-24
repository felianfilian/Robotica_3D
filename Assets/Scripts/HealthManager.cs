using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public GameObject effectPlayerDeath;

    public int maxHealth = 5;
    public int currentHealth;

    //invincibility
    private bool invincible = false;
    private float invinceTime = 2f;
    private float invinceCounter;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        FullHealth();      
    }

    private void Update()
    {
        if (invinceCounter > 0)
        {
            invinceCounter -= Time.deltaTime;
        } else
        {
            invincible = false;
            foreach (GameObject piece in PlayerController.instance.playerPieces)
            {
                piece.SetActive(true);
            }
        }
    }

    public void GetDamage(int amount)
    {
        if (!invincible)
        {
            invincible = true;
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
                invinceCounter = invinceTime;
                
                foreach(GameObject piece in PlayerController.instance.playerPieces)
                {
                    piece.SetActive(false);
                }
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
