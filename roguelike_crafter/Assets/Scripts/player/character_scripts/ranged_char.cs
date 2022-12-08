using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ranged_char : MonoBehaviour
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
    private bool isHollowPoint;
    
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
    private bool readyToShoot;
    private RaycastHit target;
    private Vector3 targetPos;

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
    private int maxCharges;
    private float current_charge_cd;
    private bool charge_cr_active;
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
    public GameObject projectile;
    public GameObject gl_object;
    public GameObject cannon_hitbox_area;
    public Transform barrel;
    public Observer observer;

    private projectile proj_script;
    private gl_projectile gl_script;
    
    public Rigidbody rb_player;
    public Camera cam;

    public GameObject pausePanel;
    private bool pauseState;

    [Header("Other")] 
    public LayerMask whatIsGround;
    public GameObject spawnPoint;

    // player input
    private InputManager inputManager;

    private void Start()
    {
        amt_of_stats = 8;
        stat_id = new List<int>();
        for (int i = 0; i < amt_of_stats; i++)
        {
            stat_id.Add(i);
        }

        passiveStacks = 0;
        base_attack_speed = attackSpeed;
        base_damage = damage;
        
        inputManager = InputManager.createInstance();
        
        slideTimer = maxSlideTime;
        amt_of_jumps = 1;
        maxAmount_of_jumps = amt_of_jumps;

        proj_script = projectile.GetComponent<projectile>();
        
        ability_useAbility = new List<bool>();
        ability_OnCooldown = new List<bool>();
        
        maxCharges = ability_1_charges;
        charge_count.text = maxCharges.ToString();

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

        gl_script = gl_object.GetComponent<gl_projectile>();
        
        readyToShoot = true;
        
        health_controller = GetComponent<healthController>();
        health_controller.setCurrentHealth(health);
        health_controller.setMaxHealth(health);
        health_controller.initializeHealth();
        health_controller.setCurrentArmor(armor);

        transform.position = spawnPoint.transform.position;
    }
    
    
    public void changePauseState()
    {
        if (pauseState)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            pauseState = false;
            pausePanel.SetActive(false);
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            pauseState = true;
            pausePanel.SetActive(true);
        }
    }

    // get input
    private void Update()
    {
        if (inputManager.pauseGame())
        {
            changePauseState();
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) && !Cursor.visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt) && Cursor.visible)
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
        
        if (ability_1_charges < maxCharges && !charge_cr_active)
            StartCoroutine(gainCharges(0));
            // start gaining a charge

        if (passiveStacks > 0 && !passive_cr_active)
            StartCoroutine(loseStack());

            // Debug.DrawRay(transform.position, Vector3.down * 3, Color.red);
    }

    // handle input
    private void FixedUpdate()
    {
        if (pauseState || Cursor.visible)
            return;
        

        if (inputManager.Attack() && readyToShoot)
            Shoot();
        
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
        bullet.GetComponent<projectile>().setDamage(calculateDamage(5));
        // Debug.LogWarning(isHollowPoint);
        bullet.GetComponent<projectile>().setHollowPointStatus(isHollowPoint);

        Invoke(nameof(resetShoot), attackSpeed);
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

    public void resetShoot()
    {
        readyToShoot = true;
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
                        StartCoroutine(startCooldown(i));
                    }
                        
                }
                else
                {
                    StartCoroutine(startCooldown(i));
                }
                
            }
        }
    }
    
    public void updateStat(int stat_id, float statToAdd)
    {
        switch (stat_id)
        {
            case 0: // health
                Debug.Log("updating health");
                // health = Convert.ToInt64(statToAdd);
                health_controller.addMaxHealth(Convert.ToInt64(statToAdd));
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
    
    private void updateMovementSpeed(float add)
    {
        //Debug.LogWarning(movement_speed);
        walk_speed += add;
        sprint_speed += add;
        jumpForce += add;
        slideForce += add;
    }

    #region Abilities
    
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
    
    // passive ideas
        // 1. free jetpack (for mobility)
        // 2. Gain stacks per kill
            // Each stack gives temporary movement speed and attack speed

        // add a stack when the player gets a kill
        
        // if at max stacks (passiveStacks == 10)
            // refresh current stack cooldown
        // if (passiveStacks < 10)
            // refresh current stack cooldown
            // add stack
        public void addPassiveStack()
        {
            // 5 - ms
            // 2 - AS
            //Debug.Log("adding a passive stack");
            
            passiveStacks++;
            updateStat(5, MS_passive_stack);
            updateStat(2, AS_passive_stack);
        }

        
        private IEnumerator loseStack()
        {
            passive_cr_active = true;
            
            float time = current_charge_cd;

            while (time > 0)
            {
                time -= Time.deltaTime;
                yield return null;
            }

            passive_cr_active = false;

            passiveStacks--;
            updateStat(5, -MS_passive_stack);
            updateStat(2, -AS_passive_stack);
        }

        // shoots an underbarrel Gl (grenade launcher)
            // will have 3 charges to use
        private void performAbility_1()
        {
            if (ability_1_charges == 0)
            {
                // Debug.Log("no charges to use");
            }
            else
            {
                ability_1_charges--;
                charge_count.text = ability_1_charges.ToString();

                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

                Vector3 gl_target;
                if (Physics.Raycast(ray, out target))
                {
                    gl_target = target.point;
                }
                else
                {
                    gl_target = ray.GetPoint(75);
                }

                Vector3 direction = gl_target - barrel.position;
                gl_object.transform.forward = direction.normalized;

                GameObject gl_round = Instantiate(gl_object, barrel.position, Quaternion.identity);
                gl_round.GetComponent<Rigidbody>().AddForce(direction.normalized * gl_script.projectile_speed, ForceMode.Impulse);
                gl_round.GetComponent<gl_projectile>().setDamage(calculateDamage(0));
                
                // Debug.Log("using a GL");
            }
            
            resetAbility(0);
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
            cannon_hitbox hitbox = cannon_hitbox_area.GetComponent<cannon_hitbox>();
            hitbox.setDamage(calculateDamage(1));
            cannon_hitbox_area.SetActive(true);
            
            // knockback for player
            
            rb_player.AddForce(knockBack_force * -cam.transform.forward, ForceMode.Impulse);
            StartCoroutine(ability_2_duration());
        }

        private IEnumerator ability_2_duration()
        {
            float time = 0.25f;

            while (time > 0)
            {
                time -= Time.deltaTime;
                yield return null;
            }
            
            cannon_hitbox_area.SetActive(false);
        }
        
        // increase attack speed and damage for a certain duration
        private void performAbility_3()
        {
            
            //attackSpeed /= 2;
            // damage *= 2;
            
            updateStat(2, 0.5f);
            updateStat(1, 1.5f);
            Debug.LogWarning(damage);
            
            StartCoroutine(ability_3_duration());
        }

        private IEnumerator ability_3_duration()
        {
            float time = ability_cooldowns[2] - ability_cooldowns[2] * 0.33f;

            while (time > 0)
            {
                // Debug.LogWarning(time);
                time -= Time.deltaTime;
                yield return null;
            }
            
            updateStat(2, -0.5f);
            updateStat(1, 1);
        }
    
        // hollow point bullets
            // while active
                // bullets do less dmg, but can apply a bleed affect
            // active only for 10 seconds

        // hollow point bleed
            // deal 10% current hp as damage per 1.5 seconds
            // max bleed stack of 3
                // bleed stack decays after 3 seconds
        private void performAbility_4()
        {
            // decrease damage by 30%
            // bullets are now hollow point bullets
            
            if (isHollowPoint)
            {

                // Debug.Log("turning off hollow points");
                
                damage += dmg_taken_away;
                isHollowPoint = false;

                StartCoroutine(startCooldown(3));
            }
            else
            {
                // Debug.Log("turning on hollow points");
                
                // dmg = 100
                dmg_taken_away = Convert.ToInt64(damage * 0.30f);
                damage -= dmg_taken_away;
                // dmg = 70
                // dmg = 80 ; dmg == 110
            
                canvasGroups[3].alpha = 0.5f;
                isHollowPoint = true;
                StartCoroutine(timer(1));
                
            }
        }

        private IEnumerator timer(float time)
        {
            while (time > 0)
            {
                time -= Time.fixedDeltaTime;
                yield return null;
            }
            
            ability_OnCooldown[3] = false;
        }
        
        private IEnumerator gainCharges(int i)
        {
            charge_cr_active = true;
        
            current_charge_cd = ability_cooldowns[i];
            while (current_charge_cd > 0)
            {
                current_charge_cd -= Time.deltaTime;
                yield return null;
            }

            ability_1_charges++;
            charge_cr_active = false;
            charge_count.text = ability_1_charges.ToString();
        }
        
        private void resetAbility(int i)
        {
            ability_OnCooldown[i] = false;
            cooldown_texts[i].gameObject.SetActive(false);
            canvasGroups[i].alpha = 1f;
        }
    
        private IEnumerator startCooldown(int i)
        {
            float cd;

            if (i == 0)
            {
                cooldown_texts[i].gameObject.SetActive(true);
                canvasGroups[i].alpha = 0.5f;
                cd = current_charge_cd;
            }
            else
            {
                cooldown_texts[i].gameObject.SetActive(true);
                canvasGroups[i].alpha = 0.5f;
                cd = ability_cooldowns[i];
            }
        
            float seconds;
        
            while (cd > 0)
            {
                if(i != 0)
                    cd -= Time.deltaTime;
                else
                    cd = current_charge_cd;
            
                if (cd < 0)
                    cd = 0;
                seconds = cd % 60;

                cooldown_texts[i].text = string.Format("{0:00}", seconds.ToString("F1"));
            
                yield return null;
            }
        
            resetAbility(i);
        }
    #endregion
}
