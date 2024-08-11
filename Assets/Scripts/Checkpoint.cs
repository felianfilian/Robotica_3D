using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject cpActive;
    public GameObject cpInactive;

    private void Start()
    {
        DeactivateCheckpoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.SetCheckpoint(transform.position);
            ActivateCheckpoint();
        }
    }

    public void ActivateCheckpoint()
    {
        CheckpointController.instance.DeactivateAllCheckpoints();
        cpActive.SetActive(true);
        cpInactive.SetActive(false);
    }

    public void DeactivateCheckpoint()
    {
        cpActive.SetActive(false);
        cpInactive.SetActive(true);
    }
}
