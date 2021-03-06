using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed; 
    int a;
    float starttime;
    bool flg = false;

    void Start()
    {
        starttime = Time.time;
    }

    void Update()
    {
        
        if(Time.time-starttime<5)
        {
           
            transform.position += new Vector3(0, 0, speed);
        }
        else
        {
            Destroy(gameObject);
            flg = false;
        }

        

    }
}
