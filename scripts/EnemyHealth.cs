using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 25f;
    public GameObject particles;
     
    void Update()
    {
        if(health <= 0f)
        {
            var x = GameObject.Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(x, 3f);
            Debug.Log("DED");
        }
    }
}
