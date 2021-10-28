using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public float spawnRate;
    public AsteroidSpawner[] spawners;

    void Awake()
    {
        StartCoroutine(SpawnRandom());
    }

    public IEnumerator SpawnRandom()
    {
        int randomSpawn = (int)Random.Range(0, spawners.Length);

        spawners[randomSpawn].Spawn();

        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnRandom());

    }

}
