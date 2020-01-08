using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class arrow_Collision : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * Speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
         if (!other.CompareTag("Player") && other.gameObject.GetComponent<Entity>())
        {
            other.gameObject.GetComponent<Entity>().GetPossessed();
        }


    }
}
