using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        Player = GameObject.Find("Player");
        Possession = Player;
        CameraTransition.gameObject.SetActive(false);
    }

    void Update()
    {
        Cancel();
        LoadScene();
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

    void LoadScene()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(1);
        }
    }
}
