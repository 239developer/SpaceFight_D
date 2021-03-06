using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour {

    public GameObject roadelement;
    public GameObject StartBlock;

    float startBlockXPos;
    int blocksCount = 20;
    float blockLength = 0;
    int safeZone = 50;
    int a = 0;

    public Transform PlayerTransf;
    List<GameObject> CurrentBlocks = new List<GameObject>();

    Vector3 startPlayerPos;

	void Start ()
    {
        startBlockXPos = PlayerTransf.position.z + 15;
        blockLength = 10;

        StartGame();
	}

    public void StartGame()
    {


        foreach (var go in CurrentBlocks)
            Destroy(go);

        CurrentBlocks.Clear();

        for (int i = 0; i < blocksCount; i++)
            SpawnBlock();
    }

    void LateUpdate ()
    {
        CheckForSpawn();
	}

    void CheckForSpawn()
    {
        if (CurrentBlocks[0].transform.position.z - PlayerTransf.position.z < -25)
        {
            SpawnBlock();
            DestroyBlock();
        }
    }

    void SpawnBlock()
    {
        GameObject block = Instantiate(roadelement, transform);
        Vector3 blockPos;

        if (CurrentBlocks.Count > 0)
            blockPos = CurrentBlocks[CurrentBlocks.Count - 1].transform.position + new Vector3(0, 0, blockLength);
        else
            blockPos = new Vector3(startBlockXPos-17, 8,0);

        block.transform.position = blockPos;

        CurrentBlocks.Add(block);
    }

    void DestroyBlock()
    {
        Destroy(CurrentBlocks[0]);
        CurrentBlocks.RemoveAt(0);
    }
}
