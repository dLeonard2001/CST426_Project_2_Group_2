using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_1 : MonoBehaviour
{

    [Header("Player Forces")] 
    public float walk_speed;
    public float sprint_speed;
    public float jump_force;
    public float slide_force;


    private float move_speed;
    [Header("Components")] 
    public Rigidbody rb_player;

    
    
    // player input
    private InputManager inputManager;
    
    
    // player state
    private enum state
    {
        walking,
        sprinting,
        sliding,
        air
    }
    private state playerState;


    private void Start()
    {
        inputManager = InputManager.createInstance();
        playerState = state.walking;
    }

    private void FixedUpdate()
    {
        HandleInput();
        
        rb_player.AddForce(move_speed * Vector3.down, ForceMode.Force);
    }

    public void HandleInput()
    {
        // walking
        // sprinting
            // sliding
        // jump 
            // air
        if (inputManager.moveForward())
        {
            rb_player.AddForce(move_speed * Vector3.forward, ForceMode.Force);
        }else if (inputManager.moveBackward())
        {
            rb_player.AddForce(move_speed * Vector3.back, ForceMode.Force);
        }

        if (inputManager.moveLeft())
        {
            rb_player.AddForce(move_speed * Vector3.left, ForceMode.Force);
        }else if(inputManager.moveRight())
        {
            rb_player.AddForce(move_speed * Vector3.right, ForceMode.Force);
        }

        if (rb_player.velocity.magnitude > move_speed)
        {
            Vector3 vel = rb_player.velocity;
            Vector3 flatVel = new Vector3(vel.x, 0f, vel.z);
            Vector3 limitedVel = move_speed * flatVel.normalized;
            
            rb_player.velocity = new Vector3(limitedVel.x, vel.y, limitedVel.z);
        }
    }
}
