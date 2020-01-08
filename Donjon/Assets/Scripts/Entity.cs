using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public bool isPlayer;
    public GameObject Anchor;
    private possesionManager possessionManager;
    public Camera cam;
    public MonoBehaviour MovementScript;

    void Start()
    {
        possessionManager = FindObjectOfType<possesionManager>();
        if (!isPlayer)
        {
            cam.gameObject.SetActive(false);
            MovementScript.enabled = false;
        }
    }
    
    void Update()
    {
        
    }

    public void GetPossessed()
    {
        possessionManager.SetPossession(gameObject);
        cam.gameObject.SetActive(true);
        MovementScript.enabled = true;
    }

    public void GetUnpossessed()
    {
        cam.gameObject.SetActive(false);
        MovementScript.enabled = false;
    }
}
