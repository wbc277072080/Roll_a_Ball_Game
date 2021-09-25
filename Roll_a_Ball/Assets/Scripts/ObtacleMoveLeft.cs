using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtacleMoveLeft : MonoBehaviour
{
    public float Speed;
    private float Time;
    void Start()
    {
        Speed = 0.1f;
        Time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Time = Time + 0.1f;
        transform.Translate(Vector3.left * Speed);

        if (Time > 8.0f) 
        {
            transform.Rotate(0, 180, 0);
            Time = 0.0f;
        }
    }
}
