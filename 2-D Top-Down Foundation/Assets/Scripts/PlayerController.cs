﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float moveSpeed;

    private Animator animator;
    private Rigidbody2D myRigidbody;

    private Vector2 lastMove; //Use Vector 2 for (x,y); not Vector 3 b/c it's (x,y,z)
    private bool playerMoving;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) //GetAxisRaw takes the input of that very second
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f)); //original movement code, before the rigidbody was implemented
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y); //In this case, Time.deltaTime made the player move a LOT slower
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) //GetAxisRaw takes the input of that very second
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f) //prevents the "skating" movement effect
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }

        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal")); //all these animator.Set(s) update the animator variables that were created wit
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
        /*In order to not make the animations take time to activate (i.e. the player starts moving, but is still in the idle animation for a little while),
        click on the transition, uncheck "Has Exit Time," uncheck "Fixed Duration," and set "Transition Duration" to 0. Supposedly, "Transition Duration
        is what causes this the most.*/
    }
  
}