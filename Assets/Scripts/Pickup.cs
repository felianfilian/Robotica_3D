 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType { heart, coin }
    public GameObject pickupEffect;
    public int amount = 1;
    public PickupType type;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
                                   
            switch(type)
            {
                case PickupType.heart:
                    if(HealthManager.instance.currentHealth >= HealthManager.instance.maxHealth)
                    {
                        break;
                    } else
                    {
                        LifeUp(amount);
                        
                    }
                    
                    break;
                case PickupType.coin:
                    CoinsUp(amount);
                    
                    break;
            
            }

            
            
        }
    }

    public void LifeUp(int amount)
    {
        HealthManager.instance.GetHealth(amount);
        Destroy(gameObject);
        if (pickupEffect != null)
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
        }
    }

    public void CoinsUp(int amount)
    {
        GameManager.instance.coinCount += amount;
        UIController.instance.UpdateUI();
        Destroy(gameObject);
        if (pickupEffect != null)
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
        }
    }

}
