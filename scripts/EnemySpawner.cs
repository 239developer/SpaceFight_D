using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyes;
    public Transform PlayerPos;
    float xpos = 0f,spawntime = 4f;
    float SpawnSleep = 2f;
    void Update()
    {
        var line = Mathf.Ceil(Random.value*3);
        switch(line)
        {
            case 1f:
                xpos = -3f;
                break;
            case 2f:
                xpos = 0f;
                break;
            case 3f:
                xpos = 3f;
                break;
        }
        var s = Random.value;
        float[] chances= {0.27f, 0.23f, 0.15f, 0.15f};
        var chance=0f;
        int count = chances.Length;
        for(int i=0; i < count; i++)
        {
            chance += chances[i];
            if (s <= chance)
            {
                if(Time.time - spawntime >= SpawnSleep)
                {
                    spawntime=Time.time;
                    GameObject enemy = GameObject.Instantiate(enemyes[i], new Vector3(xpos, 2.45f, PlayerPos.position.z + 10f), Quaternion.Euler(0f,180f,0f));
                    if(Globals.no)
                    {
                        Globals.no=false;
                        Destroy(enemy);
                    }
                }
                
            }
        }
    }
}
