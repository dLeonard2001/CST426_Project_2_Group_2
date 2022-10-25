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

    [Header("Sliding Config")] 
    public float slideTimer;
    public float maxSlideTime;
    
    private float move_speed;
    private bool isJumping;
    
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
    private state player_movement_State;


    private void Start()
    {
        inputManager = InputManager.createInstance();
        player_movement_State = state.walking;
        slideTimer = maxSlideTime;
    }

    // get input
    private void Update()
    {
        if (inputManager.Jump())
        {
            isJumping = true;
        }
    }

    // handle input
    private void FixedUpdate()
    {
        if ((slideTimer < 0 || slideTimer > 0) && !inputManager.Slide())
        {
            slideTimer = maxSlideTime;
        }
        HandleInput();
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
            move_speed = walk_speed;
            if (inputManager.Sprint())
            {
                if (inputManager.Slide() && slideTimer > 0)
                {
                    move_speed = slide_force;
                    rb_player.AddForce(move_speed * Vector3.forward, ForceMode.Impulse);
                    slideTimer -= Time.fixedDeltaTime;
                }
                else
                {
                    move_speed = sprint_speed;
                    rb_player.AddForce(move_speed * Vector3.forward, ForceMode.Impulse); 
                }
            }
            else
            {
                rb_player.AddForce(move_speed * Vector3.forward, ForceMode.Impulse);
            }
                    
        }else if (inputManager.moveBackward())
        {
            move_speed = walk_speed / 2;
            rb_player.AddForce(move_speed * Vector3.back, ForceMode.Impulse);
        }

        if (inputManager.moveLeft())
        {
            move_speed = walk_speed;
            rb_player.AddForce(move_speed * Vector3.left, ForceMode.Impulse); 
        }else if(inputManager.moveRight()) 
        {
            move_speed = walk_speed;
            rb_player.AddForce(move_speed * Vector3.right, ForceMode.Impulse);
        }

        if (isJumping)
        {
            move_speed = jump_force;
            rb_player.AddForce(move_speed * Vector3.up, ForceMode.Impulse);

            isJumping = false;
        }
        else
        {
            rb_player.AddForce(Vector3.down * 5, ForceMode.Force);
        }
            
        // cap player's movement speed
        if (rb_player.velocity.magnitude > move_speed)
        {
            Vector3 vel = rb_player.velocity;
            Vector3 flatVel = new Vector3(vel.x, 0f, vel.z);
            Vector3 limitedVel = move_speed * flatVel.normalized;
            
            rb_player.velocity = new Vector3(limitedVel.x, vel.y, limitedVel.z);
        }
    }
}
