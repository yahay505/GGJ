using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public float rpm;

    private void Start()
    {
        StartCoroutine(Sstart());
    }

    IEnumerator Sstart()
    {
        yield return null;
        while (true)
        {
            var deltaTime = (rpm / 60f)*Time.deltaTime*360f;
            transform.Rotate(transform.forward,deltaTime);
            yield return null;
        }
    }

}
