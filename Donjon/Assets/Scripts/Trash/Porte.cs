using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    bool playerHere;
    public Vector3 StartPos;
    public Vector3 EndPos;
    Vector3 PosIng;
    public float duration;

    private void Start()
    {
        StartPos = transform.position;
    }

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
        Debug.Log("Open");
    }
    void CloseDoor()
    {
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
