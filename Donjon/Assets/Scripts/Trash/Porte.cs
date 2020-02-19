using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    bool playerHere;
    public Animator animPorte;

    void Update()
    {
        if (playerHere)
        {
            OpenDoor();
        }
        if(!playerHere)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        animPorte.SetBool("Open", true);
        Debug.Log("Open");
    }
    void CloseDoor()
    {
        animPorte.SetBool("Open", false);
        Debug.Log("Close");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHere = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHere = false;
        }
    }
}
