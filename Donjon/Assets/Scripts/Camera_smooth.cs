using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_smooth : MonoBehaviour
{
    public float DistanceMax;
    public float Distance;
    public GameObject SetPositionMaxCam;

    public GameObject Player;
    public GameObject Cam;

    private void Awake()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 directeur = Cam.transform.position - Player.transform.position;
        Debug.DrawRay(Player.transform.position, directeur,Color.red ,1f);

        DistanceMax = Vector3.Distance(SetPositionMaxCam.transform.position, Player.transform.position);

        RaycastHit Hit;
        if (Physics.Raycast(Player.transform.position, directeur, out Hit, Mathf.Infinity))
        {
            Distance = Vector3.Distance(Hit.point, Player.transform.position);

            if (Distance < DistanceMax)
            {
                Cam.transform.position = Hit.point;
            }
            else if (Distance >= DistanceMax)
            {
                Cam.transform.position = SetPositionMaxCam.transform.position;
            }
        }

    }
}

