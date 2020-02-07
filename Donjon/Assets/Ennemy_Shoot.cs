using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Ennemy_Shoot : MonoBehaviour
{
    public GameObject shootPoint;
    public GameObject CheckPosition;
    public GameObject shot;
    RaycastHit hit;
    public GameObject Spine;
    public GameObject target;

    public GameObject VisionConeBlue, VisionConeRed;
    void Start()
    {
        VisionConeBlue.SetActive(true);
        VisionConeRed.SetActive(false);
    }
    
    void Update()
    {
        Shooting();
    }

    void LateUpdate()
    {
        if (target)
        {
            Spine.transform.LookAt(target.transform);
            VisionConeRed.transform.parent.transform.LookAt(target.transform);
            VisionConeBlue.SetActive(false);
            VisionConeRed.SetActive(true);
        }
        else
        {
            VisionConeBlue.SetActive(true);
            VisionConeRed.SetActive(false);
        }
    }
    void Shooting()
    {

        if (Physics.Raycast(CheckPosition.transform.position, CheckPosition.transform.forward, out hit, 20f))
        {
            if (hit.transform.CompareTag("Player"))
            {

                target = hit.transform.gameObject;
                if (Time.frameCount % 60 == 0)
                {
                    Instantiate(shot, CheckPosition.transform.position, CheckPosition.transform.rotation);
                }
            }
            else target = null;
        }
    }
}
