using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public Image healthBar;
    private float life;
    private float visibleLife;
    void OnEnable()
    {
        Shot_Movement.ennemyShot += TakeDamage;
        life = 100;
        visibleLife = 100;
    }

    void OnDisable()
    {

    }
    
    void Update()
    {
        visibleLife = Mathf.Lerp(visibleLife, life, 5f * Time.deltaTime);
        healthBar.fillAmount = visibleLife / 100;
    }


    void TakeDamage()
    {
        life -= 6;
    }
}
