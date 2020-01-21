using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Shoot : MonoBehaviour
{
    public GameObject shootPoint;
    public GameObject CheckPosition;
    public GameObject shot;
    void Start()
    {
        
    }
    
    void Update()
    {
        Shooting();
    }

    void Shooting()
    {
        RaycastHit hit;

        if (Physics.Raycast(CheckPosition.transform.position, CheckPosition.transform.forward, out hit, 20f))
        {
            if (hit.transform.CompareTag("Player"))
            {
                if (Time.frameCount % 60 == 0)
                {
                    Instantiate(shot, CheckPosition.transform.position, CheckPosition.transform.rotation);
                }
            }
        }
    }
}
