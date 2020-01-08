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
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Possession = Player;
    }
    
    void Update()
    {
        Cancel();   
    }

    public void SetPossession(GameObject entity)
    {
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
                Player.GetComponent<Entity>().GetPossessed();
                time = 0;
            }
        }

        Cancel_Circle.fillAmount = time / 1.5f;

    }
}
