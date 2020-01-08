using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Aim : MonoBehaviour
{
    public Animator anim;
    private Camera cam;

    [Header("Aiming info")]
    public GameObject Spine;

    void Start()
    {
        cam = Camera.main;
    }
    
    void Update()
    {
        Aim();
        HandleAnimation();
    }

    void LateUpdate()
    {
        if (Input.GetAxis("Zoom") >= .1f)
        {
            Quaternion addRot = Quaternion.Euler(0,90,0);
            Spine.transform.rotation = cam.transform.rotation * addRot;
        }
    }


    void Aim()
    {
        if (Input.GetAxis("Zoom") >= .1f)
        {
            transform.rotation = Quaternion.LookRotation(AlignMovementToCamera() * Vector3.forward);
            Spine.transform.rotation = cam.transform.rotation;
        }
    }

    Quaternion AlignMovementToCamera()
    {
        Quaternion newRot = Quaternion.LookRotation(cam.transform.forward);
        Vector3 nextRot = newRot.eulerAngles;
        nextRot.x = 0;
        nextRot.z = 0;
        newRot = Quaternion.Euler(nextRot);

        return newRot;
    }
    void HandleAnimation()
    {
        if (Input.GetAxis("Zoom") >= .1f)
        {
            anim.SetBool("isAiming",true);
        }
        else anim.SetBool("isAiming",false);
    }
}
