using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boitier : MonoBehaviour
{
    public string name;
    bool Event;
    public bool do_;
    GameObject Player;
    Entity entity;
    Light light_;
    public Color green;
    public GameObject[] ObjectEventToActive;

    private void Awake()
    {
        light_ = GetComponentInChildren<Light>();       
    }

    void Update()
    {
        if (Event && Input.GetButtonDown("A") && !do_ && entity.isPlayer)
        {
            Debug.Log("tourelle " + name + " desactive");
            light_.color = green;
            do_ = true;
            for (int i = 0; i < ObjectEventToActive.Length; i++)
            {
                ObjectEventToActive[i].SetActive(true);
            }
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
