using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camer : MonoBehaviour
{
    public GameObject Cam;
    public GameObject Player;
    public GameObject CamMax;
    public float DistanceMax;
    public float dd;

    private void Awake()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        var Vec = Cam.transform.position - Player.transform.position;
        RaycastHit hit;
        Debug.DrawRay(Player.transform.position, Vec, Color.red);
        if (Physics.Raycast(Player.transform.position, Vec, out hit, Mathf.Infinity))
        {
            Debug.Log("oui");
            Cam.transform.position = hit.collider.transform.position;
        }
    }
}
