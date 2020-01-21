using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy_Movement : MonoBehaviour
{
    public NavMeshAgent agent;

    [Header("Check Info")]
    public GameObject CheckPosition;
    public float checkDistance;

    private GameObject Target;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        CheckForPlayer();
    }

    
    void CheckForPlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(CheckPosition.transform.position,Target.transform.position - CheckPosition.transform.position,out hit, checkDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                FollowPlayer();
            }
        }
        
    }

    void FollowPlayer()
    {
        if (Vector3.Distance(transform.position,Target.transform.position) <= 10f)
        {
            
        }
        agent.SetDestination(Target.transform.position);
    }
}
