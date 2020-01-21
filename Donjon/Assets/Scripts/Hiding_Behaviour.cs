using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding_Behaviour : MonoBehaviour
{

    public Animator anim;
    private bool isAgainstWall;
    void Start()
    {
        
    }
    
    void Update()
    {
        checkForWall();
    }


    void WalkAgainstWall()
    {
        
    }

    void checkForWall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit, .4f))
        {
            if (hit.transform.CompareTag("SemiWall"))
            {
                isAgainstWall = true;
                anim.SetBool("IsNearWall",true);
            }
        }
    }
}
