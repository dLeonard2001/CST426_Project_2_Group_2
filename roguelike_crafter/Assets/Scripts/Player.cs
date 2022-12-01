using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// TODO: Have a toggle sprint button and make the camera lowered to simulate crouching, whatever style of crouch is your choice
public class Player : MonoBehaviour
{
    public float mouseSpeed;
    public float movementSpeed;
    Vector2 looking;
    Transform camTransform;
    CharacterController CC;
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction lookAction;

    void Awake()
    {
        CC = GetComponent<CharacterController>();
        camTransform = Camera.main.transform;
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["move"];
        lookAction = playerInput.actions["look"];

    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        lookingAround();
        updateMovement();
    }

    void lookingAround()
    {
        Vector2 lookInput = lookAction.ReadValue<Vector2>();

        looking.x += lookInput.x * mouseSpeed;
        looking.y += lookInput.y * mouseSpeed;
        looking.y = Mathf.Clamp(looking.y, -89f, 89f);

        transform.localRotation = Quaternion.Euler(0f, looking.x, 0f);
        camTransform.localRotation = Quaternion.Euler(-looking.y, 0f, 0f);
    }

    void updateMovement()
    {
        var moveInput = moveAction.ReadValue<Vector2>();
        
        Vector3 inputVect = new Vector3();
        inputVect += transform.forward * moveInput.y;
        inputVect += transform.right * moveInput.x;
        inputVect = Vector3.ClampMagnitude(inputVect, 1f);
        CC.Move(-inputVect * movementSpeed * Time.deltaTime);
    }
    public void Teleport(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        Physics.SyncTransforms();
        looking.x = rotation.eulerAngles.y;
        looking.y = rotation.eulerAngles.z;
        //vel = Vector3.zero;

    }
}