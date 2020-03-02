using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Rien : MonoBehaviour
{
   /* [MenuItem("MyMenu Test")]
    static void Do()
    {
        Debug.Log("je clique sur mon menu");
    }*/


    public AnimationCurve plot = new AnimationCurve();

    private void Update()
    {
        float value = Mathf.Sin(Time.time);

        plot.AddKey(Time.realtimeSinceStartup, value);

       //Destroy(gameObject, 10f);
    }

}
