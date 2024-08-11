using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private Transform myPosition;

    private void Start()
    {
        myPosition.position = transform.position + new Vector3(0f, 0.2f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.SetCheckpoint(myPosition);
        }
    }
}
