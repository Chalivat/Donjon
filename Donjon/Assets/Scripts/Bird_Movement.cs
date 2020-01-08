using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Movement : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Inputs")]
    public string Strafe;
    public string Forward;


    [Header("Variables")]
    public float Speed;
    public float rotateSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis(Strafe);
        float z = -Input.GetAxis(Forward);
        float w = Input.GetAxis("Shoot");
        
        transform.Rotate(z * rotateSpeed  * Time.deltaTime,0,-x * rotateSpeed * 2* Time.deltaTime);

        if (w > .1f)
        {
            rb.AddForce(transform.forward * w * Speed,ForceMode.VelocityChange);
        }

        rb.velocity = Vector3.Lerp(rb.velocity, transform.forward * rb.velocity.magnitude, 0.8f);
    }
}
