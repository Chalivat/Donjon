using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shot_Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    public float damage;

    public delegate void EnnemyShot();
    public static event EnnemyShot ennemyShot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ennemyShot();
        }
    }


}
