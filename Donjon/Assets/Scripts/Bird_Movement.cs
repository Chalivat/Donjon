using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Movement : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Inputs")]
    public string Strafe;
    public string Forward;
    public string Horizontal;

    [Header("Variables")]
    public float Speed;
    public float rotateSpeed;

    public GameObject bird;
    public GameObject camera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        Move();
        AdaptMotion();
        CameraDamping();
    }

    private void Move()
    {
        float x = Input.GetAxis(Horizontal);
        float z = -Input.GetAxis(Forward);
        float y = Input.GetAxis(Strafe);
        float w = Input.GetAxis("Shoot");
        Debug.Log(y);
        
        transform.Rotate(z * rotateSpeed  * Time.deltaTime,y * rotateSpeed *  Time.deltaTime,-x * rotateSpeed * 1* Time.deltaTime);

        if (w > .1f)
        {
            rb.AddForce(transform.forward * w * Speed,ForceMode.VelocityChange);
        }

        rb.velocity = Vector3.Lerp(rb.velocity, transform.forward * rb.velocity.magnitude, 0.8f);
    }

    private void AdaptMotion()
    {
        float z = -Input.GetAxis(Forward);
        float y = -Input.GetAxis(Strafe);
        Debug.Log("Strafe : " + y);
        Quaternion newRot = bird.transform.localRotation;
        Vector3 nextRot = newRot.eulerAngles;
        nextRot.x = z * 20;
        nextRot.z = y * 30;
        newRot = Quaternion.Euler(nextRot);

        
            bird.transform.localRotation = Quaternion.Lerp(bird.transform.localRotation, newRot, 10f * Time.deltaTime);
    }

    private void CameraDamping()
    {
        float z = -Input.GetAxis(Forward);
        float y = -Input.GetAxis(Strafe);

        Quaternion newRot = bird.transform.localRotation;
        Vector3 nextRot = newRot.eulerAngles;
        nextRot.x = z * 5;
        nextRot.z = y * 8;
        newRot = Quaternion.Euler(nextRot);

        camera.transform.localRotation = Quaternion.Lerp(camera.transform.localRotation,newRot, 5f * Time.deltaTime);
    }
}
