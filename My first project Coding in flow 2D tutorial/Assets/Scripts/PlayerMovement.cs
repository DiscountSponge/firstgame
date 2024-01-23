using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; //Rigidbody2D is the kind of varaiable
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX= 0f;

    [SerializeField]private float movespeed = 7f; // this allows us to change the values in unity
    [SerializeField]private float jumpforce = 14f;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal"); // When we set left it will be -1 and right is +1 and joysticks will have something between
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y); //this cuts down on the amount of code needed and gives joystick support
        if (Input.GetButtonDown("Jump")) // uses Unitys in built movement systems
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        UpdateAnimationUpdate();
    }
    private void UpdateAnimationUpdate()
    {
        if (dirX > 0f) // this is running to the right
        {
            anim.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f) // running left
        {
            anim.SetBool("Running", true);
            sprite.flipX = true; // flips the sprite on its x axis so it looks left
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }

}
