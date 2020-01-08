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
                transform.rotation = Quaternion.Lerp(transform.rotation,
                                                                                    Quaternion.LookRotation(characterController.velocity.normalized),
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
    }
}
