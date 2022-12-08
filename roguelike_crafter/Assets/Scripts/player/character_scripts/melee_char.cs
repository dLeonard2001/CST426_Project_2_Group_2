using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class melee_char : MonoBehaviour
{
     [Header("Character Stats")] 
    public long health;
    public long damage;
    
    // have to calculate attack speed based on item effects
    public float attackSpeed;
    public float crit_chance;
    public float crit_damage;
    public float movement_speed;
    public float armor;
    public float luck;

    public float passive_stack_time;
    public float MS_passive_stack;
    public float AS_passive_stack;
    private float base_movement_speed;
    private long base_damage;
    private float base_attack_speed;
    private List<int> stat_id;
    private int amt_of_stats;
    private int passiveStacks;

    private long dmg_taken_away;

    // access a stat correlated to its stat id 
        // 0 = health;
        // 1 = base_damage;
        // 2 = attackSpeed;
        // 3 = crit_chance;
        // 4 = crit_damge;
        // 5 = movement_speed;
        // 6 = armor;
        // 7 = luck;
        // 8 = jump amount

    private healthController health_controller;
    private bool readyToMelee;

    [Header("Ability Config")] 
    public int ability_1_charges;
    public int knockBack_force;
    public List<float> ability_cooldowns;
    public List<Image> img_abilities;
    public List<TextMeshProUGUI> cooldown_texts;
    public List<CanvasGroup> canvasGroups;
    public TextMeshProUGUI charge_count;

    private List<bool> ability_useAbility;
    private List<bool> ability_OnCooldown;
    private bool passive_cr_active;

    [Header("Player Forces")] 
    private float walk_speed;
    private float sprint_speed;
    private float jumpForce;
    private float slideForce;

    private int amt_of_jumps;
    private int maxAmount_of_jumps;
    
    private bool isJumping; // movement state

    [Header("Sliding Config")] 
    public float slideTimer;
    public float maxSlideTime;

    [Header("References/Components")]
    public Observer observer;

    public Rigidbody rb_player;
    public Camera cam;

    [Header("Other")] 
    public LayerMask whatIsGround;

    // player input
    private InputManager inputManager;
    
    private void Start()
    {
        passiveStacks = 0;
        base_attack_speed = attackSpeed;
        base_damage = damage;
        
        inputManager = InputManager.createInstance();
        
        slideTimer = maxSlideTime;
        amt_of_jumps = 1;
        maxAmount_of_jumps = amt_of_jumps;

        ability_useAbility = new List<bool>();
        ability_OnCooldown = new List<bool>();

        for (int i = 0; i < canvasGroups.Count; i++)
        {
            ability_OnCooldown.Add(false);
            ability_useAbility.Add(false);
            
            canvasGroups[i] = img_abilities[i].transform.GetComponent<CanvasGroup>();
            cooldown_texts[i].text = ability_cooldowns[i].ToString();
            cooldown_texts[i].gameObject.SetActive(false);
        }
        
        observer.setCurrentLuck(luck);

        // set speeds based on player's movement speed
        base_movement_speed = movement_speed;
        walk_speed = movement_speed;
        sprint_speed = movement_speed * 1.5f;
        jumpForce = movement_speed * 2;
        slideForce = movement_speed * 2.25f;

        readyToMelee = true;
        
        health_controller = GetComponent<healthController>();
        health_controller.setCurrentHealth(health);
        health_controller.setMaxHealth(health);
        health_controller.initializeHealth();
        health_controller.setCurrentArmor(armor);
    }
    
    // get input
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) && !Cursor.visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if (Input.GetKeyDown(KeyCode.LeftAlt) && Cursor.visible)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        if (inputManager.useAbility_1() && !ability_OnCooldown[0])
            ability_useAbility[0] = true;
        
        if (inputManager.useAbility_2() && !ability_OnCooldown[1])
            ability_useAbility[1] = true;
        
        if (inputManager.useAbility_3() && !ability_OnCooldown[2])
            ability_useAbility[2] = true;

        if (inputManager.useAbility_4() && !ability_OnCooldown[3])
        {
            ability_useAbility[3] = true;
        }
        
        if (inputManager.Jump() && amt_of_jumps > 0)
        {
            isJumping = true;
        }

        if (Physics.Raycast(transform.position, Vector3.down, 1, whatIsGround))
        {
            amt_of_jumps = maxAmount_of_jumps;
        }
        
        // start gaining a charge

        // if (passiveStacks > 0 && !passive_cr_active)
            // StartCoroutine(loseStack());

        // Debug.DrawRay(transform.position, Vector3.down * 3, Color.red);
    }

    // handle input
    private void FixedUpdate()
    {
        if (inputManager.Attack() && readyToMelee)
            Melee();
        
        transform.rotation = Quaternion.Euler(0f, cam.transform.eulerAngles.y, 0f);

        if ((slideTimer < 0 || slideTimer > 0) && !inputManager.Slide())
        {
            slideTimer = maxSlideTime;
            transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
        }
        HandleInput();
        handleAbilitiesInput();
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
            rb_player.AddForce(movement_speed / 2 * -transform.forward, ForceMode.Impulse);
        }

        if (inputManager.moveLeft())
        {
            movement_speed = walk_speed;
            rb_player.AddForce(walk_speed * -transform.right, ForceMode.Impulse); 
        }else if(inputManager.moveRight()) 
        {
            movement_speed = walk_speed;
            rb_player.AddForce(movement_speed * transform.right, ForceMode.Impulse);
        }

        if (isJumping && amt_of_jumps > 0)
        {
            movement_speed = jumpForce;
            rb_player.AddForce(movement_speed * transform.up, ForceMode.Impulse);

            amt_of_jumps--;
            isJumping = false;
        }
        else
        {
            rb_player.AddForce(-transform.up * 3, ForceMode.Force);
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
    
    private void handleAbilitiesInput()
    {
        if (ability_useAbility[3])
        {
            useAbility(3);
        }
        
        for (int i = 0; i < ability_useAbility.Count-1; i++)
        {
            if (ability_useAbility[i])
            {
                useAbility(i);
                if (i == 0)
                {
                    if (ability_1_charges <= 0)
                    {
                        // Debug.Log("out of charges");
                        //StartCoroutine(startCooldown(i));
                    }
                        
                }
                else
                {
                    //StartCoroutine(startCooldown(i));
                }
                
            }
        }
    }
    
    private void updateMovementSpeed(float add)
    {
        //Debug.LogWarning(movement_speed);
        walk_speed += add;
        sprint_speed += add;
        jumpForce += add;
        slideForce += add;
    }
    
    
    private void useAbility(int i)
    {
        ability_useAbility[i] = false;
        ability_OnCooldown[i] = true;

        switch (i)
        {
            case 0:
                //performAbility_1();
                break;
            case 1:
                //performAbility_2();
                break;
            case 2:
                // performAbility_3();
                break;
            case 3:
                //performAbility_4();
                break;
        }
    }
    
    public void updateStat(int stat_id, float statToAdd)
    {
        switch (stat_id)
        {
            case 0: // health
                health = Convert.ToInt64(statToAdd);
                break;
            case 1: // base damage
                damage = Convert.ToInt64(base_damage * statToAdd);
                break;
            case 2: // attackSpeed
                attackSpeed -= base_attack_speed * statToAdd;
                break;
            case 3: // crit_chance
                crit_chance += statToAdd;
                break;
            case 4: // crit_damage
                crit_damage += statToAdd;
                break;
            case 5: // movement speed
                // Debug.LogWarning(base_movement_speed * statToAdd);
                // movement_speed += base_movement_speed * statToAdd;
                updateMovementSpeed(base_movement_speed * statToAdd);
                break;
            case 6: // armor
                armor += statToAdd;
                break;
            case 7: // luck
                luck += statToAdd;
                observer.setCurrentLuck(luck);
                break;
            case 8: // add an extra jump
                maxAmount_of_jumps++;
                break;
        }
    }

    private void Melee()
    {
        
    }
    
    public long calculateDamage(int i)
    {
        long final_damage = damage;

        switch (i)
        {
            case 0:
                final_damage = Convert.ToInt64(final_damage * 2.5f);
                break;
            case 1:
                final_damage = Convert.ToInt64(final_damage * 2.0f);
                break;
        }
        
        float crit_percent = Random.Range(0, 101);
        
        if (crit_percent < crit_chance)
        {
            final_damage = Convert.ToInt64(final_damage * crit_damage);
        }
  
        return final_damage;
    }
}
