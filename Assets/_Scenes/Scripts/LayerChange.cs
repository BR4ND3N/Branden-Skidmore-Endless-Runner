using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChange : MonoBehaviour
{
    private float Up = 1.18f;
    private float Down = -1.18f;

    public float lane = 3f;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.isJumping == false)
        {
            if (Input.GetKeyDown("w"))
            {
                transform.position += new Vector3(0, Up, 0);
                lane -= 1f;
            }

            if (Input.GetKeyDown("s"))
            {
                transform.position += new Vector3(0, Down, 0);
                lane += 1f;
            }

            if (lane <= 0f)
            {
                transform.position += new Vector3(0, Down, 0);
                lane += 1f;
            }

            if (lane >= 6f)
            {
                transform.position += new Vector3(0, Up, 0);
                lane -= 1f;
            }
        }
        
    }

}
