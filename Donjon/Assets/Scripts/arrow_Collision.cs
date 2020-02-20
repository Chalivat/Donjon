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

    void Update()
    {
        //CheckForCollider();
    }
    void CheckForCollider()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit, 1f))
        {
            Debug.Log(hit.transform.gameObject);
            if (!hit.transform.gameObject.CompareTag("Player"))
            {
                transform.position = hit.point;
            }
            if (!hit.transform.CompareTag("Player") && hit.transform.gameObject.GetComponent<Entity>())
            {
                hit.transform.gameObject.GetComponent<Entity>().GetPossessed();   
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
         if (other.gameObject.name != "Player" && other.gameObject.GetComponent<Entity>())
        {
            Debug.Log(other.gameObject);
            other.gameObject.GetComponent<Entity>().GetPossessed();
        }


    }
}
