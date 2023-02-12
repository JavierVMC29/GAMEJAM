using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = false;

    CharacterController controller;

    float speed;
    public float speedWalk = 10f;
    public float speedRun = 15f;
    public float jump = 2f;
    public float gravity = -100f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    [SerializeField]
    private AudioSource walkSound;
    [SerializeField]
    private AudioSource runSound;
    public bool isRunning;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = speedWalk;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
            Run();
            MakeSound();
        }

    }

    void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;


        controller.Move(speed * Time.deltaTime * movement);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }


    void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speedRun;
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speedWalk;
            isRunning = false;
        }
    }

    public void MoveActive(bool condition)
    {
        canMove = condition;
    }

    private void MakeSound()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (isRunning)
            {
                runSound.enabled = true;
                walkSound.enabled = false;
            }
            else
            {
                walkSound.enabled = true;
                runSound.enabled = false;
            }
        }
        else
        {
            walkSound.enabled = false;
            runSound.enabled = false;
        }
    }
}
