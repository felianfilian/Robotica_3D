using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition;

    private float respawnTime = 2f;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        respawnPosition = PlayerController.instance.transform.position;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    public IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        UIController.instance.blackScreenOn = true;
        yield return new WaitForSeconds(respawnTime);
        PlayerController.instance.transform.position = respawnPosition;
        CameraController.instance.SetCameraPosition();
        UIController.instance.blackScreenOn = false;
        PlayerController.instance.gameObject.SetActive(true);
    }

    public void SetCheckpoint(Transform checkpointPosition)
    {
        respawnPosition = checkpointPosition.position;
    }
}
