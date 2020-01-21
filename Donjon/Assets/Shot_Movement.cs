using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shot_Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
    
    void Update()
    {
        
    }
}
