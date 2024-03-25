using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed = 6f;
    public float maxScrollSpeed = 18f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float timeAlive = 6f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask backLayer;

    // Update is called once per frame
    void FixedUpdate()
    {
        timeAlive += Time.deltaTime;
        transform.Translate(Vector2.left * Time.deltaTime * scrollSpeed);

        if (gameObject.transform.position.x <= -17.75f)
        {
            gameObject.transform.position = new Vector3(17.75f,transform.position.y,transform.position.z);
        }

        if (scrollSpeed < maxScrollSpeed)
        {
            scrollSpeed += 0.1f * Time.deltaTime;
        }
    }
}
