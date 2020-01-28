using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCamera : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        canvas.worldCamera = Camera.current;
    }

    // Update is called once per frame
    void Update()
    {
        canvas.worldCamera = Camera.current;
        Debug.Log(Camera.current);
    }
}
