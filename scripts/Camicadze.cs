using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camicadze : MonoBehaviour
{
    public float speed = 1f;
    public GameObject particles;
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

    void Update()
    {
        transform.Translate(0f, 0f, -playerMovement.speed * Time.deltaTime);
    }

    Vector3 Target()
    {
        Vector3 targ = Vector3.zero;

        targ = player.transform.position - transform.position;

        return targ;
    }

    void OnTriggerEnter()
    {
        GameObject x = GameObject.Instantiate(particles, player.transform.position + Vector3.forward * 2f, transform.rotation);
        Destroy(x, 1f);
    }
}
