using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    public static float fireTime = 5f, reloadTime = 3f;
    public float speed = 1f;
    public GameObject shell, particles;
    private bool isFiring;
    private float lastChangeTime = 0f;
    private GameObject laser;

    void Hit(GameObject other)
    {
        GameObject x = GameObject.Instantiate(particles, other.transform.position + Vector3.forward * 2f, transform.rotation);
        Destroy(x, 2.5f);
        // Destroy(gameObject);
        if(other.name == "Player")
        {
            playerMovement.health -= playerMovement.laserDPS * Time.deltaTime;
        }
    }

    void Fire()
    {
        if(isFiring)
        {
            if(Time.time - lastChangeTime < fireTime)
            {
                /* - FIRE - */
                Vector3 origin = transform.position + Vector3.up * 0.7f;
                Vector3 direction = new Vector3(0f, 0f, -25f);
                float radius = 0.125f;
                RaycastHit info;
                if(Physics.SphereCast(origin, radius, direction, out info))
                {
                    Hit(info.collider.gameObject);
                }

                Debug.DrawRay(origin, direction, Color.red, 0.1f);
            }
            else
            {
                lastChangeTime = Time.time;
                isFiring = false;
                //destroy laser
                Destroy(laser);
            }
        }
        else
        {
            if(Time.time - lastChangeTime >= reloadTime)
            {
                lastChangeTime = Time.time;
                isFiring = true;
                //Spawn laser
                laser = GameObject.Instantiate(shell, transform.position + new Vector3(0f, 0f, -15f), transform.rotation);
                laser.GetComponent<bullet>().ship = gameObject;
            }
        }
    }

    void Update()
    {
        transform.Translate(0f, 0f, -playerMovement.speedForv * Time.deltaTime);
        Fire();
    }
}
