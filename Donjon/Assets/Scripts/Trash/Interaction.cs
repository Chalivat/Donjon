using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    bool Event;
    public Rigidbody rb;

    void Update()
    {
        if (Event && Input.GetButtonDown("A"))
        {
            rb.useGravity = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Event = true;
        }
        else Event = false;
    }
}
