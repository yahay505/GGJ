using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Material material;
    bool isDissolving = false;
    float fade = 1f;
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) //buraya hani kart kullan�ld��� zaman dissolvelamas� i�in ayarlars�n 
        {
            isDissolving = true;
        }

        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }
            material.SetFloat("_Fade", fade); //property i�in
        }
    }
}
