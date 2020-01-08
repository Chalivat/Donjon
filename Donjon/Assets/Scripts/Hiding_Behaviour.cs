using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding_Behaviour : MonoBehaviour
{

    public Animator anim;

    void Start()
    {
        
    }
    
    void Update()
    {
        checkForWall();
    }

    void checkForWall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit, 1f))
        {
            if (hit.transform.CompareTag("SemiWall"))
            {
                anim.SetBool("IsNearWall",true);
            }
        }
    }
}
