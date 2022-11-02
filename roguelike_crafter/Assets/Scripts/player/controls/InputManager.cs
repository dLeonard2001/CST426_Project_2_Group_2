using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private PlayerControls playerControls;
    private static InputManager instance;

    public static InputManager createInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        playerControls = new PlayerControls();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 Look()
    {
        return playerControls.player.look.ReadValue<Vector2>();
    }

    public bool moveForward()
    {
        return playerControls.player.Forward.IsPressed();
    }

    public bool moveBackward()
    {
        return playerControls.player.Backward.IsPressed();
    }

    public bool moveLeft()
    {
        return playerControls.player.Left.IsPressed();
    }

    public bool moveRight()
    {
        return playerControls.player.Right.IsPressed();
    }

    public bool Jump()
    {
        return playerControls.player.Jump.WasPressedThisFrame();
    }

    public bool Slide()
    {
        return playerControls.player.Slide.IsPressed();
    }

    public bool Sprint()
    {
        return playerControls.player.Sprint.IsPressed();
    }

    public bool useAbility_1()
    {
        return playerControls.player.Ability_1.WasPressedThisFrame();
    }

    public bool useAbility_2()
    {
        return playerControls.player.Ability_2.WasPressedThisFrame();
    }
    
    public bool useAbility_3()
    {
        return playerControls.player.Ability_3.WasPressedThisFrame();
    }
    
    public bool useAbility_4()
    {
        return playerControls.player.Ability_4.WasPressedThisFrame();
    }
    
    public bool useAbility_5()
    {
        return playerControls.player.Ability_5.WasPressedThisFrame();
    }

    public bool Attack()
    {
        return playerControls.player.attack.IsPressed();
    }

}
