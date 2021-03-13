using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed; 

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, (speed + playerMovement.speedForv) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name != "Player")
        {
            other.gameObject.GetComponent<EnemyHealth>().health -= playerMovement.damage;
            Destroy(gameObject);
        }
    }
}
