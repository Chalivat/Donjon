using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecupArc : MonoBehaviour
{
    bool Event;
    public Shoot Shoot_s;

    void Update()
    {
        if (Event && Input.GetButtonDown("A"))
        {
            var oui = GameObject.Find("Player");
            Shoot_s = oui.GetComponent<Shoot>();
            Shoot_s.enabled = true;
            Destroy(gameObject);
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
