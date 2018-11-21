using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* TO DO
 * array of sectors where enemies are spawned 
 * sector is two points in percents 
 * (first: 10, second: 30, enemy will spawn on the interval of 10% from screen start to 30%)
 */
public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemyPrefabs;

    public Transform spawnPoint;

    public float spawnMargin = 0.3f;

    public float spawnInterval = 1f;

    private float countdown;

    void Start()
    {
        //first enemy will be spawned after spawnInterval
        countdown = spawnInterval;
    }

    void Update ()
    {
        //spawn enemy with spawnInterval
        if (countdown <= 0f)
        {
            SpawnEnemy();
            countdown = spawnInterval;
        }

        countdown -= Time.deltaTime;
	}

    void SpawnEnemy()
    {
        float rightBorder = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - spawnMargin;
        float leftBorder = -rightBorder;

        Vector2 spawnPosition = new Vector2(Random.Range(leftBorder, rightBorder), spawnPoint.position.y);

        Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPosition, Quaternion.identity);
        Debug.Log("Enemy spawned!");
    }
}
