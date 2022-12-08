using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    InputAction interactAction;
    public List<GameObject> playerSpawnLocations;

    void Awake()
    {
        StartCoroutine(delayedStart());
        CC = GetComponent<CharacterController>();
        camTransform = Camera.main.transform;
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["move"];
        lookAction = playerInput.actions["look"];
        interactAction = playerInput.actions["interact"];
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        lookingAround();
        updateMovement();
        //updateGravity();
    }

    void updateGravity()
    {
        var gravity = Physics.gravity * Time.deltaTime;
        movementSpeed = CC.isGrounded ? -1f : movementSpeed + gravity.y;
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
    // ! while intergrating with the main branch have the a function to detect the end portal and trigger it on the box trigger

    IEnumerator delayedStart()
    {
        Debug.Log("Start Delay");
        yield return new WaitForSeconds(3);
        Debug.Log("Delay Ends");
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Player TP");
        for (int c = 0; c < temp.Length; c++)
        {
            playerSpawnLocations.Add(temp[c]);
        }
        int selection = Random.Range(0, temp.Length);
        Teleport(playerSpawnLocations[selection].transform.position, Quaternion.identity);
    }
}