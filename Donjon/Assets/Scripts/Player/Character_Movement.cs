using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{

    public Animator anim;

    [Header("Movement info")]
    public float Speed;
    public float rotationSpeed;

    [Header("Inputs")]
    public string Strafe;
    public string Forward;

    private CharacterController characterController;
    private Camera cam;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;
    }
    
    void Update()
    {
        Move();
        Rotate();
        HandleAnimation();
        groundCheck();
    }

    void Move()
    {
        float x = Input.GetAxis(Strafe);
        float z = -Input.GetAxis(Forward);

        
        Vector3 direction = new Vector3(x,0,z);
        direction = AlignMovementToCamera() * direction;
        characterController.SimpleMove(direction * Speed * Time.deltaTime);
    }

    void Rotate()
    {
        if (Input.GetAxis("Zoom") < .1f)
        {
            if (characterController.velocity.magnitude >= .3f)
            {
                Quaternion newRot = Quaternion.identity;
                if (!characterController.isGrounded)
                {
                     newRot = Quaternion.LookRotation(characterController.velocity.normalized);
                    Vector3 nextRot = newRot.eulerAngles;
                    nextRot.x = 0;
                    nextRot.z = 0;
                    newRot = Quaternion.Euler(nextRot);
                }
                else
                {
                    newRot = Quaternion.LookRotation(characterController.velocity.normalized);
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
        anim.SetFloat("Velocity",characterController.velocity.magnitude);
        anim.SetFloat("VelocityZ", characterController.velocity.z /2.5f);
        anim.SetFloat("VelocityX", characterController.velocity.x / 2.5f);
        anim.SetBool("IsGrounded",characterController.isGrounded);
    }

    void groundCheck()
    {
        if (Physics.Raycast(transform.position,characterController.velocity,5f))
        {
            if (!characterController.isGrounded)
            {
                anim.SetBool("IsGrounded",true);
            }
        }
    }
}
