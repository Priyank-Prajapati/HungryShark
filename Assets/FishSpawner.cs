using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    //Variables that control spawning fish

    [Header("Wave Settings")]
    public GameObject[] fish = new GameObject[4];   //What are we spawning
    public Vector2 spawnValue;  //Where are we spawning;
    public int fishCount;     //How many fish are we spawning per wave?

    [Header("Wave Time Settings")]
    public float startWait;     //How long until the first wave?
    public float spawnWait;     //How long between waves?
    public float waveWait;      //How long between each wave of fish?

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWaves()
    {
        //Initial delay before the first wave
        yield return new WaitForSeconds(startWait);

        //Start spawning waves of fishes
        while (true)
        {
            //Spawn some fishes
            for (int i = 0; i < fishCount; i++)
            {
                //Spawn a single fish
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));

                Instantiate(fish[Random.Range(0,4)], spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);     //Wait for the next wave
            }

            yield return new WaitForSeconds(waveWait);          //Wait for the next wave of fishes
        }
    }
}
