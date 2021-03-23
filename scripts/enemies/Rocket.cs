using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject player, particles;
    public static float speed = 5f;
    public static float degreesPerSecond = 30f;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
        transform.position += new Vector3(0f, 0f, playerMovement.speedForv * Time.deltaTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.down, player.transform.position - transform.position), degreesPerSecond * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy")
        {
            if(other.name == "Player")
                playerMovement.health -= playerMovement.rocketDmg;
            var x = GameObject.Instantiate(particles, transform.position, transform.rotation);
            Destroy(x, 2.5f);
            Destroy(gameObject);
        }
    }
}
