using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLaser : MonoBehaviour
{
    public static float speed = 20f;

    void Update()
    {
        transform.position -= Time.deltaTime * new Vector3(0f, 0f, speed - playerMovement.speedForv);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            playerMovement.health -= playerMovement.laserDmg;
            Destroy(gameObject);
        }
    }
}
