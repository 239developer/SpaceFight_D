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


    }
}
