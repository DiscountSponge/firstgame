using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; //Rigidbody2D is the kind of varaiable
    private BoxCollider2D coll; // box collider of the player
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX= 0f;

    [SerializeField]private float movespeed = 7f; // this allows us to change the values in unity
    [SerializeField]private float jumpforce = 14f;
    [SerializeField] private LayerMask jumpableground;
    private enum MovementState {idle, Running, Jumping, Falling }
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal"); // When we set left it will be -1 and right is +1 and joysticks will have something between
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y); //this cuts down on the amount of code needed and gives joystick support
        if (Input.GetButtonDown("Jump") && IsGrounded()) // uses Unitys in built movement systems
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        UpdateAnimationUpdate();
    }
    private void UpdateAnimationUpdate()
    {
        MovementState state;
        if (dirX > 0f) // this is running to the right
        {
            state = MovementState.Running;
            sprite.flipX = false;
        }
        else if (dirX < 0f) // running left
        {
            state = MovementState.Running;
            sprite.flipX = true; // flips the sprite on its x axis so it looks left
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f) // Checking for jumping we cant use 0 as its never exactly zero for reasons idk 
        {
            state = MovementState.Jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {

       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableground);
    }
}
