using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    private GameObject player;
    private Rigidbody rb;

    void Start()
    {
        player = GameObject.Find("Player")
    }
}
