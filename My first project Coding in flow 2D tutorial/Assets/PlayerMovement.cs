using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; //Rigidbody2D is the kind of varaiable
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal"); // When we set left it will be -1 and right is +1 and joysticks will have something between
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y); //this cuts down on the amount of code needed and gives joystick support
        if (Input.GetButtonDown("Jump")) // uses Unitys in built movement systems
        {
            rb.velocity = new Vector2(rb.velocity.x, 14);
        }
               
    }
}
