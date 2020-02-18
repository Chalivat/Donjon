using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Script : MonoBehaviour
{
    public GameObject Player;
    public GameObject AImage;
    void Start()
    {
        Player = GameObject.Find("Player");
    }
    
    void Update()
    {
        Display();
    }

    void Display()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= 2)
        {
            AImage.SetActive(true);
        }
        else AImage.SetActive(false);
    }
}
