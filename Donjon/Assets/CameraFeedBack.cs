using UnityEngine;
using System.Collections;

public class CameraFeedBack : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;


    
    private float originalShake;
    void Awake()
    {
        originalShake = shakeAmount;
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
        Shoot.onShoot += ShakeShoot;
        Character_Movement.onGround += ShakeGround;
        Shot_Movement.ennemyShot += ShakeGround;
    }

    void OnDisable()
    {
        Shoot.onShoot -= ShakeShoot;
        Character_Movement.onGround -= ShakeGround;
        Shot_Movement.ennemyShot -= ShakeGround;
    }

    void ShakeShoot()
    {
        shakeDuration = originalShake;
    }

    void ShakeGround()
    {
        shakeDuration = originalShake * 1.25f;
    }
    void Update()
    {
        
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    
}
