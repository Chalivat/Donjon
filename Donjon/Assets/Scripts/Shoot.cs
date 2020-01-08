using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject shootPoint;
    public Camera cam;
    private float bendForce;
    void Start()
    {
        cam = GetComponent<Entity>().cam;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        Quaternion aiming = Quaternion.identity;
        RaycastHit hit;
        bool asHit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 500f))
        {
            aiming = Quaternion.LookRotation(hit.point - shootPoint.transform.position);
            asHit = true;
        }
        else asHit = false;
        if (Input.GetAxis("Shoot") <.1f)
        {
            if (bendForce > 1)
            {
                if (asHit)
                {
                    Instantiate(Arrow, shootPoint.transform.position, aiming);
                }
                else
                {
                    Instantiate(Arrow,shootPoint.transform.position,shootPoint.transform.rotation * Quaternion.Euler(0,90,0));
                }
                bendForce = 0;
            }
        }


        if (Input.GetAxis("Shoot") > .1f)
        {
            bendForce += Time.deltaTime;
        }
        else bendForce -= Time.deltaTime;

        bendForce = Mathf.Clamp(bendForce, 0, 2);

    }

    


}
