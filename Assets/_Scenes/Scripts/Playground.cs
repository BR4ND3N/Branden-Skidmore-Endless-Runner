using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Playground : MonoBehaviour
{
    public int health = 0;

    private int maxHealth = 10;

    int healthMax = 10;
   

    int integer = 5;
    float floatNum = 55.7f;
    public bool isPlayerAlive = true;
    string aliveMessage = "I'm Screaming Internally...";
    string deadMessage = "Finally!";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(health);

        Debug.Log(maxHealth);

        if (health < maxHealth)

        {
            isPlayerAlive = false;
        }
       
        if (isPlayerAlive == true) 

        {
            Debug.Log(aliveMessage);
        }
        else
        {
            Debug.Log(deadMessage);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
