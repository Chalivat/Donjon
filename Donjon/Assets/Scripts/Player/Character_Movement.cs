using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{

    public Animator anim;

    [Header("Movement info")]
    public float Speed;
    public float normalSpeed;
    public float crouchSpeed;
    public float rotationSpeed;

    [Header("Inputs")]
    public string Strafe;
    public string Forward;

    
    private Rigidbody rb;
    private Camera cam;

    private bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }
    
    void Update()
    {
        Debug.Log(isGrounded);
        Rotate();
        HandleAnimation();
        groundCheck();
        Crouch();
    }

    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float x = Input.GetAxis(Strafe);
        float z = -Input.GetAxis(Forward);

        
        Vector3 direction = new Vector3(x,0,z);
        direction = AlignMovementToCamera() * direction;
        //characterController.SimpleMove(direction * Speed * Time.deltaTime);
        if (isGrounded)
        {
         rb.velocity = direction * Speed * Time.deltaTime;
        }
    }

    void Rotate()
    {
        if (Input.GetAxis("Shoot") < .1f)
        {
            if (rb.velocity.magnitude >= .3f)
            {
                Quaternion newRot = Quaternion.identity;
                if (!isGrounded)
                {
                     newRot = Quaternion.LookRotation(rb.velocity.normalized);
                    Vector3 nextRot = newRot.eulerAngles;
                    nextRot.x = 0;
                    nextRot.z = 0;
                    newRot = Quaternion.Euler(nextRot);
                }
                else
                {
                    newRot = Quaternion.LookRotation(rb.velocity.normalized);
                }


                transform.rotation = Quaternion.Lerp(transform.rotation,
                                                                                    newRot,
                                                                                    rotationSpeed * Time.deltaTime);
            }
        }
        
    }

    Quaternion AlignMovementToCamera()
    {
        Quaternion newRot = Quaternion.LookRotation(cam.transform.forward);
        Vector3 nextRot = newRot.eulerAngles;
        nextRot.x = 0;
        nextRot.z = 0;
        newRot = Quaternion.Euler(nextRot);

        return newRot;
    }


    void HandleAnimation()
    {
        anim.SetFloat("Velocity",rb.velocity.magnitude);
        anim.SetFloat("VelocityZ", rb.velocity.z /2.5f);
        anim.SetFloat("VelocityX", rb.velocity.x / 2.5f);
        anim.SetBool("IsGrounded",isGrounded);
    }

    void groundCheck()
    {
        if (Physics.Raycast(transform.position,rb.velocity,5f))
        {
            if (!isGrounded)
            {
                anim.SetBool("IsGrounded",true);
            }
        }

        if (Physics.Raycast(transform.position,Vector3.down,1.2f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void Crouch()
    {
        if (Input.GetAxis("LeftStick") > .1f)
        {
            anim.SetBool("isCrouching",!anim.GetBool("isCrouching"));
        }

        if (anim.GetBool("isCrouching"))
        {
            Speed = crouchSpeed;
        }
        else Speed = normalSpeed;
    }
}
