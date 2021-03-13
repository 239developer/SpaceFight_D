using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public static int explosionDmg = 50, laserDPS = 20;
    public static int maxHealth = 100;
    public static float health;
    public static float speed = 10.0f;
    public static float speedForv = 10.0f;

    public float sleep = 0.2f;
    public float laserBias = 0.42f;
    float spawntime;
    bool flg;

    private CharacterController _charController;
    public GameObject bullet;
    public Slider healthBar;

    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;

        _charController = GetComponent<CharacterController>();
    }

    void Update()
    { 
        /* --- MOVEMENT --- */

        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector3 movement = new Vector3(deltaX, 0, speedForv);
        movement *= Time.deltaTime;
        _charController.Move(movement);

        if ((Input.GetButton("Jump")) && !flg || (Input.GetButton("Fire1")) && !flg)
        {
            spawntime = Time.time;
            flg = true;
            GameObject.Instantiate(bullet, transform.position + new Vector3(laserBias, 0f, 0f), transform.rotation);
        }

        if (flg && Time.time - spawntime > sleep)
        {
            flg = false;
        }

        /* --- HEALTH --- */

        if(health < 0f)
            health = 0f;
        healthBar.value = health;
    }
}
