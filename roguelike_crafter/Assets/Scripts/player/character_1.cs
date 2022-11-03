using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class character_1 : MonoBehaviour
{

    [Header("Character Stats")] 
    public long health;
    public long base_damage;
    public float attackSpeed;
    public float crit_chance;
    public float crit_damage;
    public float movement_speed;
    public float luck;

    private healthController health_controller;
    private bool readyToShoot;
    private RaycastHit target;
    private Vector3 targetPos;

    [Header("Ability Config")] 
    public float ability_1_cooldown;
    public float ability_2_cooldown;
    public float ability_3_cooldown;
    public float ability_4_cooldown;
    
    private float ability_1_max_cooldown;
    private float ability_2_max_cooldown;
    private float ability_3_max_cooldown;
    private float ability_4_max_cooldown;

    [Header("Player Forces")] 
    private float walk_speed;
    private float sprint_speed;
    private float jumpForce;
    private float slideForce;

    private bool isGrounded;
    private bool isJumping; // movement state

    [Header("Sliding Config")] 
    public float slideTimer;
    public float maxSlideTime;

    [Header("References/Components")] 
    public GameObject projectile;
    public Transform attackPosition;

    private projectile proj_script;
    
    public Rigidbody rb_player;
    public Camera cam;

    [Header("Layers")] 
    public LayerMask whatIsGround;
    
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
    
    // shooting logic
        // vec3 v;
        // ray.ViewPortRay(0.5, 0.5, 0);
            // if(raycast)
                // v = raycast.point;
            // else 
                // v = raycast.GetPoint(75);
                
            // get the direction to send our bullet
                // c = b - a;
                    // direction = v.position - barrel.position;
                
            // rotate bullet's transform to face forward
                // bullet.transform.forward = direction.normalized;
            // add force to bullet
                // bullet.AddForce(direction.normalized * bulletspeed, impulse);
    
    private void Start()
    {
        inputManager = InputManager.createInstance();
        player_movement_State = state.walking;
        slideTimer = maxSlideTime;
        
        // set character stats
        // health = 100;
        // attackSpeed = 2.5f;
        // movement_speed = 5;
        // luck = 0.5f;

        // set speeds based on player's movement speed
        walk_speed = movement_speed;
        sprint_speed = movement_speed * 1.5f;
        jumpForce = movement_speed * 2;
        slideForce = movement_speed * 2.25f;

        readyToShoot = true;

        proj_script = projectile.GetComponent<projectile>();
        projectile.GetComponent<projectile>().setDamage(base_damage);

        health_controller = GetComponent<healthController>();
        health_controller.setCurrentHealth(health);
        health_controller.setMaxHealth(health);
        health_controller.initializeHealth();
    }

    // get input
    private void Update()
    {
        
        if (inputManager.Jump())
        {
            isJumping = true;
        }

        if (Physics.Raycast(transform.position, Vector3.down, 1, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        Debug.DrawRay(transform.position, Vector3.down * 3, Color.red);
    }

    // handle input
    private void FixedUpdate()
    {
        if (inputManager.Attack() && readyToShoot)
        {
            Shoot();
        }
        
        transform.rotation = Quaternion.Euler(0f, cam.transform.eulerAngles.y, 0f);

        if ((slideTimer < 0 || slideTimer > 0) && !inputManager.Slide())
        {
            slideTimer = maxSlideTime;
            transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
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
            movement_speed = walk_speed;
            if (inputManager.Sprint())
            {
                if (inputManager.Slide() && slideTimer > 0)
                {
                    movement_speed = slideForce;
                    rb_player.AddForce(movement_speed * transform.forward, ForceMode.Impulse);
                    slideTimer -= Time.fixedDeltaTime;
                    transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(1f, 0.5f, 1), transform.localScale.z);
                }
                else
                {
                    movement_speed = sprint_speed;
                    rb_player.AddForce(movement_speed * transform.forward, ForceMode.Impulse); 
                }
            }
            else
            {
                rb_player.AddForce(movement_speed * transform.forward, ForceMode.Impulse);
            }
                    
        }else if (inputManager.moveBackward())
        {
            movement_speed = walk_speed / 2;
            rb_player.AddForce(movement_speed * -transform.forward, ForceMode.Impulse);
        }

        if (inputManager.moveLeft())
        {
            movement_speed = walk_speed;
            rb_player.AddForce(movement_speed * -transform.right, ForceMode.Impulse); 
        }else if(inputManager.moveRight()) 
        {
            movement_speed = walk_speed;
            rb_player.AddForce(movement_speed * transform.right, ForceMode.Impulse);
        }

        if (isJumping && isGrounded)
        {
            movement_speed = jumpForce;
            rb_player.AddForce(movement_speed * transform.up, ForceMode.Impulse);

            isJumping = false;
            isGrounded = false;
        }
        else
        {
            rb_player.AddForce(-transform.up * 5, ForceMode.Force);
        }
            
        // cap player's movement speed
        if (rb_player.velocity.magnitude > movement_speed)
        {
            Vector3 vel = rb_player.velocity;
            Vector3 flatVel = new Vector3(vel.x, 0f, vel.z);
            Vector3 limitedVel = movement_speed * flatVel.normalized;
            
            rb_player.velocity = new Vector3(limitedVel.x, vel.y, limitedVel.z);
        }
    }
    
    // fire the gun 
    private void Shoot()
    {
        // Debug.Log("shooting");
        readyToShoot = false;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out target))
        {
            targetPos = target.point;
        }
        else
        {
            targetPos = ray.GetPoint(75);
        }

        Vector3 direction = targetPos - attackPosition.position;

        projectile.transform.forward = direction.normalized;
        
        // bullet creation
        GameObject bullet = Instantiate(projectile, attackPosition.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * proj_script.projectileSpeed, ForceMode.Impulse);
        bullet.GetComponent<projectile>().setDamage(base_damage);
        
        Invoke(nameof(resetShoot), 0.25f);
    }

    public void resetShoot()
    {
        readyToShoot = true;
    }
    
}
