using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Have a toggle sprint button and make the camera lowered to simulate crouching, whatever style of crouch is your choice
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float gravity = -17.62f; // original number is 8.81
    public float speed;
    public CharacterController CC; // move command
    public Transform groundPos; // ground trigger position
    public LayerMask mask; // looking for a layer
    public float jumpHeight = 5f; // adjustable
    //float groundRadius = 0.4f; // adjustable for ground checks
    bool grounded;
    [SerializeField] bool run;
    Vector3 vel; // maybe this shouldn't be a vector???
    void Start()
    {
        run = false;
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            vel.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            grounded = false;
        }

        if ((Input.GetKeyDown(KeyCode.LeftShift) && !run) && grounded)
        {
            Debug.Log("I AM RUNNING");
            StartCoroutine(sprinting(movement));
        }

        else if ((Input.GetKey(KeyCode.LeftShift) && run) && grounded)
        {
            Debug.Log("I SHOULD BE RUNNING");
            CC.Move(movement * speed * 2);
        }

        else if ((Input.GetKeyUp(KeyCode.LeftShift) && run))
        {
            Debug.Log("I HAVE STOPPED RUNNING");
            run = false;
        }

        else
        {
            CC.Move(movement * speed);
        }
        
        vel.y += gravity * Time.deltaTime;
        CC.Move(vel * Time.deltaTime);
    }

    public void gravityReset()
    {
        grounded = true;
        gravity = -2f;
    }

    IEnumerator sprinting(Vector3 moveVector)
    {
        yield return new WaitForSeconds(1);
        run = true;
    }
}