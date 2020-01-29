using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitre_break : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Arrow"))
        {
            Destroy(gameObject);
        }
    }
}
