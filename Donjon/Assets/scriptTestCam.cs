using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTestCam : MonoBehaviour
{
    public Camera cam;
    public GameObject Player;
    private Shoot shoot;
    private RaycastHit hit;
    private Vector3 baseOffset;
    public float speed;
    private float distance;


    void Start()
    {
        cam = Camera.main;
        Player = GameObject.Find("Player");
        shoot = Player.GetComponent<Shoot>();
        baseOffset = Player.transform.position - cam.transform.position;
        distance = Vector3.Distance(cam.transform.position, Player.transform.position);
    }
    void Update()
    {
        ShootRaycast();
    }
    void LateUpdate()
    {
        
        CheckForObstacle();
    }

    void ShootRaycast()
    {
        RaycastHit hit;
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 500f, Color.blue);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 500f))
        {
            Debug.DrawRay(hit.point,hit.normal,Color.red);
            shoot.setVector(hit.point);
        }
    }

    void CheckForObstacle()
    {
        if (Physics.Raycast(Player.transform.position, cam.transform.position - Player.transform.position, out hit, distance))
        {
            cam.transform.position = hit.point;
        }

    }
}
