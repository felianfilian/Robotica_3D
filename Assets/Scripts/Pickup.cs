using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType { heart, coin }
    public PickupType type;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
                                   
            switch(type)
            {
                case PickupType.heart:
                    Debug.Log("HEAL");
                    break;
                case PickupType.coin:
                    Debug.Log("COIN");
                    break;
            }
        }
    }

    public void LifeUp()
    {

    }
    
}
