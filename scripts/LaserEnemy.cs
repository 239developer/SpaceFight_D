using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    public static float fireTime = 3f, reloadTime = 1f;
    public float speed = 1f;
    public GameObject particles;
    private bool isFiring;
    private float lastChangeTime = 0f;

    void Fire()
    {
        if(isFiring)
        {
            if(Time.time - lastChangeTime < fireTime)
            {
                /* - FIRE - */
                Vector3 origin = transform.position + Vector3.up * 0.7f;
                Vector3 direction = origin + new Vector3(0f, 0f, -10f);
                Debug.DrawRay(origin, direction - origin, Color.red, 0.1f);
            }
            else
            {
                lastChangeTime = Time.time;
                isFiring = false;
                //destroy laser
            }
        }
        else
        {
            if(Time.time - lastChangeTime >= reloadTime)
            {
                lastChangeTime = Time.time;
                isFiring = true;
                //Spawn laser
            }
        }
    }

    void Update()
    {
        transform.Translate(0f, 0f, -playerMovement.speedForv * Time.deltaTime);
        Fire();
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject x = GameObject.Instantiate(particles, other.gameObject.transform.position + Vector3.forward * 2f, transform.rotation);
        Destroy(x, 2.5f);
        Destroy(gameObject);
        if(other.name == "Player")
        {
            playerMovement.health -= playerMovement.explosionDmg;
        }
    }
}
