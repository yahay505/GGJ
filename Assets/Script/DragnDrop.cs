using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class DragnDrop : MonoBehaviour
{
    private Camera mainCam;
    void Start()
    {
        mainCam=Camera.main;
    }


    
    private void OnMouseDown()
    {
        StopAllCoroutines();

        StartCoroutine(twine(1.1f,1.3f));

        
    }
    private void OnMouseUp()
    {
        StopAllCoroutines();
        StartCoroutine(twine(1.3f,1.1f));

    }



    private void OnMouseDrag()
    {
        var x=mainCam.ScreenToWorldPoint(Input.mousePosition);
        x.z = transform.position.z;
        transform.position =x ;
    }

    private void OnMouseEnter()
    {
        StopAllCoroutines();
        StartCoroutine(twine(1.0f, 1.1f));


    }
    //
    private void OnMouseExit()
    {
        StopAllCoroutines();
        StartCoroutine(twine(1.1f, 1.0f));
    }
    
        IEnumerator twine(float a,float b)
        {
           
            for (int i = 0; i < 4; i++)
            {
                transform.localScale = Vector3.one* math.remap(0f, 3f, a, b, i);
                yield return null;
            }
        }
    
}
