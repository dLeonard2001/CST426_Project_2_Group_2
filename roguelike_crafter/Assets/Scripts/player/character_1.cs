using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class character_1 : MonoBehaviour
{
    [Header("Character Stats")] 
    public long health;
    public long base_damage;
    
    // have to calculate attack speed based on item effects
    public float attackSpeed;
    public float crit_chance;
    public float crit_damage;
    public float movement_speed;
    public float armor;
    public float luck;

    private List<int> stat_id;
    private int amt_of_stats;
    // access a stat correlated to its stat
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
    private bool readyToShoot;
    private RaycastHit target;
    private Vector3 targetPos;

    [Header("Ability Config")] 
    public List<float> ability_cooldowns;
    public List<Image> img_abilities;
    public List<TextMeshProUGUI> cooldown_texts;
    public List<CanvasGroup> canvasGroups;

    private List<bool> ability_useAbility;
    private List<bool> ability_OnCooldown;

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
    public GameObject projectile;
    public Transform barrel;

    private projectile proj_script;
    
    public Rigidbody rb_player;
    public Camera cam;

    [Header("Other")] 
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
    
    private void Start()
    {
        amt_of_stats = 8;
        stat_id = new List<int>();
        for (int i = 0; i < amt_of_stats; i++)
        {
            stat_id.Add(i);
        }
        
        inputManager = InputManager.createInstance();
        
        slideTimer = maxSlideTime;
        amt_of_jumps = 1;
        maxAmount_of_jumps = amt_of_jumps;

        proj_script = projectile.GetComponent<projectile>();
        
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

        // set speeds based on player's movement speed
        updateMovementSpeed();

        readyToShoot = true;
        
        health_controller = GetComponent<healthController>();
        health_controller.setCurrentHealth(health);
        health_controller.setMaxHealth(health);
        health_controller.initializeHealth();
    }

    // get input
    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.LeftAlt))
        // {
        //     Cursor.visible = true;
        //     Cursor.lockState = CursorLockMode.Confined;
        // }
        
        if (inputManager.useAbility_1() && !ability_OnCooldown[0])
            ability_useAbility[0] = true;
        
        if (inputManager.useAbility_2() && !ability_OnCooldown[1])
            ability_useAbility[1] = true;
        
        if (inputManager.useAbility_3() && !ability_OnCooldown[2])
            ability_useAbility[2] = true;
        
        if (inputManager.useAbility_4() && !ability_OnCooldown[3])
            ability_useAbility[3] = true;
        
        if (inputManager.Jump() && amt_of_jumps > 0)
        {
            isJumping = true;
        }

        if (Physics.Raycast(transform.position, Vector3.down, 1, whatIsGround))
        {
            amt_of_jumps = maxAmount_of_jumps;
        }

        // Debug.DrawRay(transform.position, Vector3.down * 3, Color.red);
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

        if (isJumping && amt_of_jumps > 0)
        {
            movement_speed = jumpForce;
            rb_player.AddForce(movement_speed * transform.up, ForceMode.Impulse);

            amt_of_jumps--;
            isJumping = false;
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

        Vector3 direction = targetPos - barrel.position;

        projectile.transform.forward = direction.normalized;
        
        // bullet creation
        GameObject bullet = Instantiate(projectile, barrel.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * proj_script.projectileSpeed, ForceMode.Impulse);
        bullet.GetComponent<projectile>().setDamage(calculateDamage());
        
        Invoke(nameof(resetShoot), 0.25f);
    }

    public long calculateDamage()
    {

        long final_damage = base_damage;
        
        float crit_percent = Random.Range(0, 101);
        if (crit_percent < crit_chance)
        {
            final_damage = Convert.ToInt64(base_damage * crit_damage);
        }
        
        return final_damage;
    }

    public void resetShoot()
    {
        readyToShoot = true;
    }

    private void handleAbilitiesInput()
    {
        for (int i = 0; i < ability_useAbility.Count; i++)
        {
            if (ability_useAbility[i])
            {
                useAbility(i);
                StartCoroutine(startCooldown(i));
            }
        }
    }

    private void useAbility(int i)
    {
        ability_useAbility[i] = false;
        ability_OnCooldown[i] = true;

        switch (i)
        {
            case 0:
                performAbility_1();
                break;
            case 1:
                performAbility_2();
                break;
            case 2:
                performAbility_3();
                break;
            case 3:
                performAbility_4();
                break;
        }
    }

    private void resetAbility(int i)
    {
        ability_OnCooldown[i] = false;
        cooldown_texts[i].gameObject.SetActive(false);
        canvasGroups[i].alpha = 1f;
    }
    
    private IEnumerator startCooldown(int i)
    {
        cooldown_texts[i].gameObject.SetActive(true);
        canvasGroups[i].alpha = 0.5f;
        float cd = ability_cooldowns[i];
        float seconds;
        
        while (cd > 0)
        {
            cd -= Time.deltaTime;
            if (cd < 0)
                cd = 0;
            seconds = cd % 60;

            cooldown_texts[i].text = string.Format("{0:00}", seconds.ToString("F1"));
            
            yield return null;
        }
        
        resetAbility(i);
    }

    public void updateStat(int stat_id, float statToAdd)
    {
        switch (stat_id)
        {
            case 0: // health
                health = Convert.ToInt64(statToAdd);
                break;
            case 1: // base damage
                base_damage = Convert.ToInt64(statToAdd);
                break;
            case 2: // attackSpeed
                attackSpeed += statToAdd;
                break;
            case 3: // crit_chance
                crit_chance += statToAdd;
                break;
            case 4: // crit_damage
                crit_damage += statToAdd;
                break;
            case 5: // movement speed
                movement_speed += movement_speed * statToAdd;
                updateMovementSpeed();
                break;
            case 6: // armor
                armor += statToAdd;
                break;
            case 7: // luck
                luck += statToAdd;
                break;
            case 8: // add an extra jump
                maxAmount_of_jumps++;
                break;
        }
    }

    private void updateMovementSpeed()
    {
        walk_speed = movement_speed;
        sprint_speed = movement_speed * 1.5f;
        jumpForce = movement_speed * 2;
        slideForce = movement_speed * 2.25f;
    }

    #region Abilities
    
    // passive ideas
        // 1. free jetpack (for mobility)
        // 2. Gain stacks per kill
            // Each stack gives temporary movement speed and attack speed
        private void passive()
        {
            
        }

        // shoots an underbarrel Gl (grenade launcher)
            // maybe will have 3 charges to use?
        private void performAbility_1()
        {
        
        }
    
        // shoot a big cannon
            // knocks enemies back
            // knocks player back (for mobility purposes)
                // player gets blasted in the opposite direction they are facing
                    // looking forward
                        // gets blasted backwards
                    // looking down
                        // gets blasted upwards 
        private void performAbility_2()
        {
        
        }
        
        // increase attack speed and damage for a certain duration
        private void performAbility_3()
        {
        
        }
    
        // no ideas, yet
        private void performAbility_4()
        {
            
        }
    #endregion
}
