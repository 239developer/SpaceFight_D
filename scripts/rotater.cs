using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotater : MonoBehaviour
{
    public float x, y, z;

    void Update()
    {
        transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }
}
