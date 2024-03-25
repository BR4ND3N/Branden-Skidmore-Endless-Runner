using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabScrolling : MonoBehaviour
{
    [SerializeField] private float obstacleSpeed = 3f;
    [SerializeField] private float maxObstacleSpeed = 18f;

    private float timeUntilObstacleSpawn;

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * Time.deltaTime * obstacleSpeed);

        if (obstacleSpeed < maxObstacleSpeed)
        {
            obstacleSpeed += 0.1f * Time.deltaTime;
        }
    }
}
