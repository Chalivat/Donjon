using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class possesionManager : MonoBehaviour
{
    private GameObject Possession;
    private GameObject Player;
    private float time;
    public Image Cancel_Circle;

    public PossetionTransition CameraTransition;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Possession = Player;
        CameraTransition.gameObject.SetActive(false);
    }
    
    void Update()
    {
        Cancel();   
    }

    public void SetPossession(GameObject entity)
    {
        if (Possession != Player)
        {
            CameraTransition.gameObject.SetActive(true);
            CameraTransition.Transition(entity);
        }
        Possession.GetComponent<Entity>().GetUnpossessed();
        Possession = entity;
        
    }

    void Cancel()
    {
        if (Possession != Player)
        {
            if (Input.GetAxis("B") > .1f)
            {
                time += Time.deltaTime;
                Debug.Log("lol : " + time);
            }

            if (time >= 1.5f)
            {
                TeleportPlayer();
                Player.GetComponent<Entity>().GetPossessed();
                time = 0;
            }
        }

        Cancel_Circle.fillAmount = time / 1.5f;

    }

    void TeleportPlayer()
    {
        Player.transform.position = Possession.transform.position;
    }
}
