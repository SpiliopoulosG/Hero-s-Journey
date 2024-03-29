using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0) {
            int rand = Random.Range(0, obstaclePatterns.Length);
            GameObject enemySpawner = Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            Destroy(enemySpawner, timeBtwSpawn + 1f);
            timeBtwSpawn = startTimeBtwSpawn + 0.25f;
            if (startTimeBtwSpawn > minTime) {
                startTimeBtwSpawn -= decreaseTime;
            }
        } else {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
