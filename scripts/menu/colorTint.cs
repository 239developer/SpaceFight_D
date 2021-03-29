using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorTint : MonoBehaviour
{
    public bool tint;
    public Image img;
    public float tintTime = 0.5f;
    public Color cl0, cl1, cl2;
    private float lastTintTime;
    private int i = 1;

    void Update()
    {
        if(tint)
        {
            if(Time.time - lastTintTime > tintTime)
            {
                if(i == 1)
                {
                    img.color = cl2;
                    i = 2;
                }
                else if(i == 2)
                {
                    img.color = cl1;
                    i = 1;
                }
                lastTintTime = Time.time;
            }
        }
        else
        {
            img.color = cl0;
        }
    }
}
