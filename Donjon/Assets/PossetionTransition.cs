using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossetionTransition : MonoBehaviour
{
    private bool isTransition;
    private GameObject target;
    private Camera cam;
    public float speed;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.enabled = isTransition;
        if (isTransition)
        {
            goTo();
        }
    }

    public void Transition(GameObject targetCamera)
    {
        target = targetCamera;
        isTransition = true;
    }

    void goTo()
    {
       // transform.Translate((target.transform.position - transform.position).normalized * speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position,target.transform.position,speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);

        if (Vector3.Distance(transform.position, target.transform.position) < 1f)
        {
            isTransition = false;
            target = null;
        }
    }
}
