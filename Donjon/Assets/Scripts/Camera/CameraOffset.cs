using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    #region posNrot
    [Header("Position")]
    [SerializeField]
    float distance;
    [SerializeField]
    float height;
    [SerializeField]
    float width;
    [Header("Rotation")]
    [SerializeField]
    float tilt;
    [SerializeField]
    float pan;
    [SerializeField]
    float roll;
    #endregion

    Vector3 initialPos;
    public Vector3 targetPosition;
    public float zoomSpeed;

    void Start()
    {
        initialPos = transform.localPosition;
    }
    
    void FixedUpdate()
    {
        AimZoom();
    }

    void OnValidate()
    {
        transform.localPosition = new Vector3(width, height, distance);
        transform.localRotation = Quaternion.Euler(tilt, pan, roll);
    }

    void AimZoom()
    {
        if (Input.GetAxis("Zoom") > .1f)
        {
            Debug.Log("Lol");
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, zoomSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPos, zoomSpeed * Time.fixedDeltaTime);
        }
    }


}
