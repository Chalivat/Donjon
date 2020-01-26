using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossetionTransition : MonoBehaviour
{
    private bool isTransition;
    private GameObject target;

    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        transform.Translate(target.transform.position - transform.position * speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
    }
}
