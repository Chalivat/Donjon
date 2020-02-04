using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject shootPoint;
    public Camera cam;
    private float bendForce;

    public Image bar1;
    public Image bar2;

    public delegate void ShootEvent();
    public static event ShootEvent onShoot; //Event triggered when Shooting

    void Start()
    {
        cam = GetComponent<Entity>().cam;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        AdapteUI(bendForce);
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
            if (bendForce > .4f)
            {
                onShoot();
                if (asHit)
                {
                    Instantiate(Arrow, shootPoint.transform.position, aiming);
                }
                else
                {
                    Instantiate(Arrow,shootPoint.transform.position,cam.transform.rotation);
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


    void AdapteUI(float charge)
    {


        bar1.fillAmount = charge * 1 / .4f;
        bar2.fillAmount = charge * 1/ .4f;

        if (charge >= 1f)
        {
            bar1.color = Color.green;
        }

    }



    

}
