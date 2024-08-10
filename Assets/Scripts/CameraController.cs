using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController instance;

    public Transform target;
    public Vector3 offset;

    private void Awake()
    {
        instance = this;

        if (target != null) 
        {
            offset = transform.position - target.position;
        } else
        {
            offset = new Vector3(0f, 2f, -5f);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 endPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, endPosition, 0.1f); // 10 is the follow speed
    }
}
