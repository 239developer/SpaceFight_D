using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camicadze : MonoBehaviour
{
    public float speed = 1f;
    private GameObject player;
    private Rigidbody rb;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 targ = Target();
        rb.velocity = targ / targ.magnitude * speed;
    }

    Vector3 Target()
    {
        Vector3 targ = Vector3.zero;

        targ = player.transform.position;

        return targ;
    }
}
