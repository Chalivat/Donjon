using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Rat_AlignToGround : MonoBehaviour
{
    private Camera cam;
    public float rotateSpeed;
    public string Horizontal;

    private Rat_Movement ratMovement;
    void Start()
    {
        ratMovement = transform.parent.GetComponent<Rat_Movement>();
    }
    
    void LateUpdate()
    {
        AlignToGround();
    }

    void Rotate()
    {
        float x = Input.GetAxis(Horizontal);


    }
    void AlignToGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,Vector3.down,out hit, 1.5f))
        {
            //transform.rotation = transform.rotation * Quaternion.FromToRotation(transform.up, hit.normal);
            //transform.rotation =  Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            Debug.Log(hit.transform.gameObject);
            Quaternion newRot = Quaternion.LookRotation(hit.normal);
            Quaternion upToForward = Quaternion.Euler(-90f,0,0);
            transform.rotation = newRot * upToForward;
        }
    }

    Quaternion AlignMovementToCamera(Vector3 up)
    {
        Quaternion newRot = Quaternion.LookRotation(up) * transform.rotation;
        Vector3 nextRot = newRot.eulerAngles;
        //nextRot.x = 0;
        //nextRot.z = 0;
        newRot = Quaternion.Euler(nextRot);

        return newRot;
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
}
