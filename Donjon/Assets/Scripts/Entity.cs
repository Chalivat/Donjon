using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class Entity : MonoBehaviour
{

    public bool isPlayer;
    public GameObject Anchor;
    private possesionManager possessionManager;
    public Camera cam;
    public MonoBehaviour MovementScript;

    

    void Awake()
    {
        possessionManager = FindObjectOfType<possesionManager>();
        Anchor = Instantiate(Anchor);
        ConstraintSource source = new ConstraintSource();
        source.sourceTransform = transform;
        source.weight = 1;
        Anchor.GetComponent<PositionConstraint>().AddSource(source);
        cam = Anchor.transform.GetChild(0).GetChild(0).GetComponent<Camera>();
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
