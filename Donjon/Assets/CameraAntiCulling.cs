using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAntiCulling : MonoBehaviour
{
    private GameObject Player;
    public GameObject cam;
    private RaycastHit hit;

    private Vector3 BaseOffset;
    private Vector3 currentOffset;

    private bool isWall;

    public float speed;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        cam = transform.GetChild(0).transform.GetChild(0).gameObject;
        BaseOffset = transform.localPosition;
    }
    
    void Update()
    {
        //Debug.DrawRay(Player.transform.position, transform.position - Player.transform.position, Color.green);
        //CheckForObstacle();
    }

    void CheckForObstacle()
    {
        //Debug.Log(transform.TransformPoint(cam.transform.localPosition));
        if (Physics.Raycast(Player.transform.position,cam.transform.position - Player.transform.position,out hit,500f))
        {
            //transform.Translate(hit.point - transform.position);
        }
        else transform.localPosition = Vector3.Lerp(transform.localPosition,BaseOffset,speed * Time.deltaTime);
    }
}
