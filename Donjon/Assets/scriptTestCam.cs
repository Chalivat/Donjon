using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTestCam : MonoBehaviour
{
    public Camera cam;
    public GameObject Player;
    private Shoot shoot;
    //public delegate void Hitted(Vector3 point);
    //public static Hitted Hit;
    void Start()
    {
        cam = Camera.main;
        Player = GameObject.Find("Player");
        shoot = Player.GetComponent<Shoot>();
    }
    
    void Update()
    {
        ShootRaycast();
    }

    void ShootRaycast()
    {
        RaycastHit hit;
        Debug.DrawRay(cam.transform.position,cam.transform.forward * 500f,Color.blue);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 500f))
        {
            shoot.setVector(hit.point);
        }
        

    }
}
