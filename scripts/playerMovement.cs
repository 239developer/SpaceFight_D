using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Permissions;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float speedForv = 10.0f;
    public float sleep = 0.2f;
    float spawntime;
    bool flg;
    float ShootBoost=2.5f;
    public bool BoostShoot=false;
    float ShootBoostTime;
    float ShieldBoost=2.5f;
    public bool BoostShield=false;
    float ShieldBoostTime;
    float DamageBoost=2.5f;
    public bool BoostDamage=false;
    float DamageBoostTime;

    private CharacterController _charController;
    public GameObject bullet;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector3 movement = new Vector3(deltaX, 0, speedForv);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

        if ((Input.GetButton("Jump")) && !flg || (Input.GetButton("Fire1")) && !flg)
        {
            spawntime = Time.time;
            flg = true;
            GameObject.Instantiate(bullet,transform.position-new Vector3(1.1f,-2,0),transform.rotation);
        }

        if (flg && Time.time - spawntime > sleep)
        {
            flg = false;
        }

        if (BoostShoot && Time.time-ShootBoostTime>ShootBoost)
        {
            sleep=0.2f;
        }
        if (BoostShield && Time.time-ShieldBoostTime>ShieldBoost)
        {
            
        }
        if (BoostDamage && Time.time-DamageBoostTime>DamageBoost)
        {
            sleep=0.2f;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name=="BoostShoot")
        {
            sleep = 0.05f;
            ShootBoostTime=Time.time;
            BoostShoot=true;
        }
        if (col.gameObject.name=="BoostShield")
        {
            ShieldBoostTime=Time.time;
            BoostShield=true;
        }
        if (col.gameObject.name=="BoostDamage")
        {
            sleep=0.15f;
            DamageBoostTime=Time.time;
            BoostDamage=true;
        }
    }
}
