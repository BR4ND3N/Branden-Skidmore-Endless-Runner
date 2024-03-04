using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            //TODO connect this to a game Manager and trigger GameOver();
        }
    }
}