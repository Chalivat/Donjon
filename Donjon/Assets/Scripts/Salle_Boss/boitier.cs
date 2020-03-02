using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boitier : MonoBehaviour
{
    public string name;
    bool Event;
    public bool do_;


    void Update()
    {
        if (Event && Input.GetButtonDown("A") && !do_)
        {
            Debug.Log("tourelle " + name + " desactive");
            do_ = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Event = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Event = false;
        }
    }
}
