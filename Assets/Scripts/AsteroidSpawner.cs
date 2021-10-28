using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float spawnRate;

    public GameObject[] asteroidPrefabs;

    public Player player;
    

    public void Spawn()
    {
        Vector2 direction = player.transform.position - transform.position;
        GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], transform.position, transform.rotation);
        if (asteroid.GetComponent<Asteroid>())
        {
            asteroid.GetComponent<Asteroid>().Move(direction);
        }else if (asteroid.GetComponent<ExplosiveAsteroid>())
        {
            asteroid.GetComponent<ExplosiveAsteroid>().Move(direction);
        }
    }


}
