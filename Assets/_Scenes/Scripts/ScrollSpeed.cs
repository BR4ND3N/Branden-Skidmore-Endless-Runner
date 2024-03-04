using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSpeed : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float scrollSpeed = 6f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * scrollSpeed);
    }
}
