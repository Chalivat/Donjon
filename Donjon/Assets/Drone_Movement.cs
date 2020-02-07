using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Drone_Movement : MonoBehaviour
{
    public CinemachineDollyCart cart;
    public GameObject Target;
    void Start()
    {
        cart = GetComponent<CinemachineDollyCart>();
    }
    
    void Update()
    {
        
    }

    void LookAtPlayer()
    {

    }
}
