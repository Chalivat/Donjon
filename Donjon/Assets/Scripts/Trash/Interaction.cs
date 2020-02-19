using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    bool Event;
    public Rigidbody rb;
    public GameObject Player;
    Entity entity;

    void Update()
    {
        if (Event && !entity.isPlayer && Input.GetButtonDown("A"))
        {
            rb.useGravity = true;
            Debug.Log("je suis rat");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Event = true;
            Player = other.gameObject;
            entity = Player.GetComponent<Entity>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Event = false;
            Player = null;
        }
    }
}
