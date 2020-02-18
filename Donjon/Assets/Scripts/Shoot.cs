using System.Collections;
using System.Collections.Generic;
using Bolt;
using UnityEditor;
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


    public LineRenderer line;

    private Vector3 point;
    bool asHit;
    void OnEnable()
    {
        //scriptTestCam.Hit += setVector;
    }

    void OnDisable()
    {
        //scriptTestCam.Hit -= setVector;
    }
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
        Debug.Log("camPos" + cam.transform.position);
        AdapteUI(bendForce);
        SlowTime();
    }

    void LateUpdate()
    {
        asHit = false;
    }

    public void setVector(Vector3 value)
    {
        point = value;
        asHit = true;
    }
    void Fire()
    {
        Quaternion aiming = Quaternion.identity;
        aiming = Quaternion.LookRotation(point - shootPoint.transform.position);
        
        if (Input.GetAxis("Shoot") <.1f)
        {
            if (bendForce > .4f)
            {
                onShoot();//evenement delegate
                if (asHit)
                {
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
