﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_FinSalleA : MonoBehaviour
{
    public Shoot Shoot_s;
    public GameObject MurIncassable;
    public Camera CamEvent;
    bool eventStart;

    void Awake()
    {
        var player = GameObject.Find("Player");
        Shoot_s = player.GetComponent<Shoot>();
    }

    void FixedUpdate()
    {
        if (Shoot_s.enabled == true && !eventStart)
        {
            StartCoroutine(EventGo());
        }
    }
    IEnumerator EventGo()
    {
        eventStart = true;
        CamEvent.enabled = true;
        CamEvent.depth = 1;
        yield return new WaitForSeconds(1f);
        MurIncassable.SetActive(false);
        yield return new WaitForSeconds(1f);
        CamEvent.enabled = false;
    }
}
