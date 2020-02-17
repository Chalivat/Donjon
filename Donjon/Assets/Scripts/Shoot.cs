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

    private Character_Movement characterMovement;
    public Image bar1;
    public Image bar2;

    public delegate void ShootEvent();
    public static event ShootEvent onShoot; //Event triggered when Shooting

    void Start()
    {
        cam = GetComponent<Entity>().cam;
        characterMovement = GetComponent<Character_Movement>();

        bar1 = GameObject.Find("Bar1").GetComponent<Image>();
        bar2 = GameObject.Find("Bar2").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        AdapteUI(bendForce);
        SlowTime();
    }

    void Fire()
    {
        Quaternion aiming = Quaternion.identity;
        RaycastHit hit;
        bool asHit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 500f))
        {
            Ray testRay = new Ray(cam.transform.position, cam.transform.forward);
            Debug.DrawRay(cam.transform.position, cam.transform.forward,Color.green);
            Debug.Log(hit.transform.gameObject);
            aiming = Quaternion.LookRotation(hit.point - shootPoint.transform.position);
            Debug.DrawRay(hit.point, Vector3.up, Color.blue);
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
                    //Instantiate(Arrow, shootPoint.transform.position, aiming);
                    Instantiate(Arrow, shootPoint.transform.position,aiming);
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
            bendForce += Time.unscaledDeltaTime;
        }
        else bendForce -= Time.unscaledDeltaTime;

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



    void SlowTime()
    {
        if (!characterMovement.isGrounded && Input.GetAxis("Shoot") >= 1f)
        {
            Time.timeScale = .05f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }
    }

}
