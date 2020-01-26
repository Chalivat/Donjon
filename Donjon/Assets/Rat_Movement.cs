using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat_Movement : MonoBehaviour
{
    public GameObject Rat;
    public float speed;
    public float rotateSpeed;
    private Camera cam;
    private Rigidbody rb;

    [Header("Inputs")] public string Strafe;
    public string Forward;
    public string rightTrigger;

    private float x, z;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponent<Entity>().cam;
    }

    void FixedUpdate()
    {
        x = Input.GetAxis(Strafe);
        z = -Input.GetAxis(Forward);
        if (isGrounded)
        {
            Move();
        }
    }

    void Update()
    {
        groundCheck();
        if (isGrounded)
        {
            Rotate();
        }

    }

    void Move()
    {
        Vector3 direction = new Vector3(x, 0, z);
        direction = AlignMovementToCamera() * direction;
        rb.velocity = Rat.transform.forward * speed * direction.magnitude;
    }

    void Rotate()
    {
        Vector3 direction = new Vector3(x, 0, z);
        direction = AlignMovementToCamera() * direction;
        Quaternion newRot = Quaternion.LookRotation(direction);

        Quaternion forwardToUp = Quaternion.FromToRotation(transform.up,AlignToGround());
        newRot = forwardToUp * newRot;
        Vector3 nextRot = newRot.eulerAngles;
        nextRot.y += x * 50f * Time.deltaTime;
        
        Rat.transform.rotation =Quaternion.Lerp(Rat.transform.rotation, newRot, rotateSpeed * Time.deltaTime);
    }

    Quaternion AlignMovementToCamera()
    {
        Quaternion newRot = Quaternion.LookRotation(cam.transform.forward);
        Vector3 nextRot = newRot.eulerAngles;
        nextRot.x = 0;
        nextRot.z = 0;
        newRot = Quaternion.Euler(nextRot);

        return newRot;
    }

    Vector3 AlignToGround()
    {
        RaycastHit hit;
        Quaternion finalRot = Quaternion.identity;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            //transform.rotation = transform.rotation * Quaternion.FromToRotation(transform.up, hit.normal);
            //transform.rotation =  Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            Debug.Log(hit.transform.gameObject);
            Quaternion newRot = Quaternion.LookRotation(hit.normal);
            Quaternion upToForward = Quaternion.Euler(90f, 0, 0);

            finalRot = newRot * upToForward;
        }

        return hit.normal;
    }

    void groundCheck()
        {
            if (Physics.Raycast(transform.position, Vector3.down, 0.4f))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
    }

