using System.Collections;
using System.Collections.Generic;
// using System.Security.Cryptography;
// using System.Security.Permissions;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public static float damage = 3.33f;
    public static int explosionDmg = 50, laserDPS = 20, rocketDmg = 34, laserDmg = 3;
    public static int maxHealth = 100;
    public static float health;
    public static float speed = 7f;
    public static float speedForv = 10.0f;
    public static float maxFiretime = 5f;

    private static bool isFiring = false;

    public float sleep = 0.2f;
    public float laserBias = 0.42f;
    float spawntime;
    bool flg;
    private float temperature = 0f;
    private bool isCooling = false;

    private CharacterController _charController;
    public GameObject bullet, heatAim;
    public Slider healthBar, steering, heatOMeter;
    public button fireButton;

    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;

        _charController = GetComponent<CharacterController>();
    }

    void Update()
    { 
        /* --- VARS --- */

        if(isFiring && !isCooling)
            temperature += Time.deltaTime;
        else
            temperature -= Time.deltaTime;
        if(temperature < 0f)
        {
            isCooling = false;
            temperature = 0f;
        }
        isFiring = fireButton.GetComponent<button>().buttonPressed;
        if(temperature >= maxFiretime)
            isCooling = true;
        heatOMeter.value = temperature / maxFiretime;

        heatAim.GetComponent<colorTint>().tint = isCooling;

        float s = steering.value - steering.maxValue / 2f;
        float moveX = Math.Sign(s) * Math.Sign(Mathf.Floor(Math.Abs(s)));
        
        /* --- MOVEMENT --- */

        float deltaX = moveX * speed;
        Vector3 movement = new Vector3(deltaX, 0, speedForv);
        movement *= Time.deltaTime;
        _charController.Move(movement);

        /* --- FIRING --- */

        if (isFiring && !flg && !isCooling)
        {
            // SceneManager.LoadScene(0);
            spawntime = Time.time;
            flg = true;
            var shot = GameObject.Instantiate(bullet, transform.position + new Vector3(laserBias, 0f, 0f), transform.rotation);
            shot.GetComponent<bullet>().ship = gameObject;
        }

        if (flg && Time.time - spawntime > sleep / (1f + temperature / maxFiretime))
        {
            flg = false;
        }

        /* --- HEALTH --- */

        if(health < 0f)
            health = 0f;
        healthBar.value = health;

        if(health <= 0f)
        {
            SceneManager.LoadScene(0);
        }
    }
}