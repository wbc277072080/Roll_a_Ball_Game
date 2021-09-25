using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // keep all pick up items rotating
    void Update()
    {
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
    }
}
