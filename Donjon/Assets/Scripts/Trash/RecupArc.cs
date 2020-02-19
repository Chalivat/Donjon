using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecupArc : MonoBehaviour
{
    bool Event;
    public Shoot Shoot_s;
    public GameObject Player;
    Entity entity;

    void Update()
    {
        if (Event && !entity.isPlayer && Input.GetButtonDown("A"))
        {
            Shoot_s = Player.GetComponent<Shoot>();
            Shoot_s.enabled = true;
            Destroy(gameObject);
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
