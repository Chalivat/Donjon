using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Script : MonoBehaviour
{
    public GameObject Player;
    public GameObject Canvas;
    public GameObject AImage;
    public GameObject BImage;
    public GameObject RTImage;
    public Image Circle;
    public Camera cam;
    public DefilementDialogue defilementDialogue;

    public GameObject Rat;
    
    private bool isDialogueBegun;
    void Start()
    {
        Player = GameObject.Find("Player");
        defilementDialogue.enabled = false;
        cam.gameObject.SetActive(false);
        BImage.SetActive(false);
        RTImage.SetActive(false);
    }
    
    void Update()
    {
        Display();
        whileDialogue();
        Possesion();
    }


    void Possesion()
    {
        if (defilementDialogue.dialogueEnded)
        {
            RTImage.SetActive(true);
            Circle.gameObject.SetActive(true);

            if (Input.GetAxis("Shoot") >.1f)
            {
                Circle.fillAmount += Time.deltaTime;
                if (Circle.fillAmount >= 1)
                {
                    Rat.GetComponent<Entity>().GetPossessed();
                    cam.gameObject.SetActive(false);
                    Circle.fillAmount = 0;
                    RTImage.SetActive(false);
                    Circle.fillAmount = 0;
                    defilementDialogue.dialogueEnded = false;
                }
            }
        }
    }
    void whileDialogue()
    {
        if (isDialogueBegun)
        {
            BImage.SetActive(true);
            if (Input.GetButtonDown("B"))
            {
                BImage.SetActive(false);
                isDialogueBegun = false;
                cam.gameObject.SetActive(false);
                Canvas.GetComponent<DefilementDialogue>().ResetText();
                defilementDialogue.enabled = false;
                AImage.SetActive(true);
            }
        }
    }
    void Display()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= 3)
        {
            Canvas.SetActive(true);
            if (Input.GetButtonDown("A"))
            {
                //begin dialogue
                defilementDialogue.enabled = true;
                isDialogueBegun = true;
                //AImage.SetActive(false);
                cam.gameObject.SetActive(true);
            }
        }
        else
        {
            Canvas.SetActive(false);
            cam.gameObject.SetActive(false);
        }
    }
}
