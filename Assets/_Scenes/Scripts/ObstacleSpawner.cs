using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 2f;
    [SerializeField] private float spawnTimeMin = 2f;
    [SerializeField] private float spawnTimeMax = 6f;
    [SerializeField] private float obstacleSpeed = 3f;
    [SerializeField] private float Spawn1;
    [SerializeField] private float Spawn2;
    [SerializeField] private float Spawn3;
    [SerializeField] private float Spawn4;
    [SerializeField] private float Spawn5;

    private float timeUntilObstacleSpawn;

    public LayerMask lane;

    // Update is called once per frame
    private void Update()
    {
        SpawnLoop();

    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            Spawn();
            obstacleSpawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            timeUntilObstacleSpawn = 0f;
        }

    }
    private void Spawn()
    {
            if (gameObject.transform.position.y == .35f)
            {
                GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

                GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

                Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
                obstacleRB.velocity = Vector2.left * obstacleSpeed;

                spawnedObstacle.layer = LayerMask.NameToLayer("Lane 1");
            }

            else if (gameObject.transform.position.y == -.9f)
            {
            GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

            Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * obstacleSpeed;

            spawnedObstacle.layer = LayerMask.NameToLayer("Lane 2");
            }

            else if (gameObject.transform.position.y == -2.15f)
            {
            GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

            Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * obstacleSpeed;

            spawnedObstacle.layer = LayerMask.NameToLayer("Lane 3");
            }

        else if (gameObject.transform.position.y == -3.25f)
        {
            GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

            Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * obstacleSpeed;

            spawnedObstacle.layer = LayerMask.NameToLayer("Lane 4");
        }

        else if (gameObject.transform.position.y == -4.5f)
        {
            GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

            Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * obstacleSpeed;

            spawnedObstacle.layer = LayerMask.NameToLayer("Lane 5");
        }
    }
}
