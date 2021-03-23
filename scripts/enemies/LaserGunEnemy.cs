using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunEnemy : MonoBehaviour
{
    public static float fireTime = 5f, reloadTime = 0.33f;
    public float speed = 1f;
    public GameObject shell;
    public static float k = 0.67f;
    private float lastFire = 0f;
    private Vector3 posBias = new Vector3(0f, 0f, 0f);
    private Quaternion rotBias = Quaternion.identity;

    void Fire()
    {
        if(Time.time - lastFire > reloadTime)
        {
            var x = GameObject.Instantiate(shell, transform.position + posBias, transform.rotation * rotBias);
            Destroy(x, 5f);
            lastFire = Time.time;
        }
    }

    void Update()
    {
        var u = k * (transform.position.x - GameObject.Find("Player").transform.position.x) * Time.deltaTime;
        transform.Translate(u, 0f, -playerMovement.speedForv * Time.deltaTime);
        Fire();
    }
}