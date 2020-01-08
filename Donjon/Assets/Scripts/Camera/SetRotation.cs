using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{
    public string Tag;
    GameObject Target;
    [SerializeField]
    float rotateSpeed;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag(Tag);
    }
    
    void FixedUpdate()
    {
        Aim();
    }

    void Aim()
    {
        float x = rotateSpeed * Input.GetAxis("Vertical") * Time.fixedDeltaTime;
        float y = rotateSpeed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        transform.Rotate(x, 0, 0);
        transform.Rotate(0, y, 0, Space.World);
    }
}
