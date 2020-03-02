using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boitier_general : MonoBehaviour
{
    public boitier[] boitier_;
    public GameObject[] miniLights;

    public GameObject firstpart;
    public GameObject secondpart;
    bool finish;

    public Material green;
    public Material red;

    private void Start()
    {
        secondpart.SetActive(false);
        firstpart.SetActive(true);
        for (int i = 0; i < miniLights.Length; i++)
        {
            miniLights[i].GetComponent<Renderer>().material = red;
        }
    }

    void Update()
    {
        boitierT4();
        SetMat();
    }

    void SetMat()
    {
        if (!finish)
        {
            for (int i = 0; i < boitier_.Length; i++)
            {
                if (boitier_[i].do_)
                {
                    var mat = miniLights[i].GetComponent<Renderer>().material = green;
                }
            }
        }
    }

    void boitierT4()
    {
        if (boitier_[0].do_ && boitier_[1].do_ && boitier_[2].do_)
        {
            finish = true;
            StartCoroutine(wait());
            IEnumerator wait()
            {
                yield return new WaitForSeconds(1f);
                secondpart.SetActive(true);
                firstpart.SetActive(false);
            }
        }
    }
}
