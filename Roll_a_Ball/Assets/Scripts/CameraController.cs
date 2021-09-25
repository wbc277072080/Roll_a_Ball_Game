using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    //calculate offset
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    ///keep camara going with player
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
