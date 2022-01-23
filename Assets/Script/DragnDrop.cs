using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DragnDrop : MonoBehaviour
{
    private Camera mainCam;
    private Coroutine twineCoro;
    public bool safe=true;
    void Start()
    {
        mainCam = Camera.main;
    }


    private void OnMouseDown()
    {
        if (!enabled)
            return;
        if (twineCoro != null)
            StopCoroutine(twineCoro);
        safe = false;
        twineCoro = StartCoroutine(twine(1.3f, 2f));
    }

    private void OnMouseUp()
    {
        if (!enabled)
            return;
        if (twineCoro != null)
            StopCoroutine(twineCoro);
        twineCoro = StartCoroutine(twine(2f, 1.3f));
    }


    private void OnMouseDrag()
    {
        if (!enabled)
            return;
        var x = mainCam.ScreenToWorldPoint(Input.mousePosition);
        x.z = transform.position.z;
        transform.position = x;
    }

    private void OnMouseEnter()
    {
        if (!enabled)
            return;

        if (twineCoro != null)
            StopCoroutine(twineCoro);
        safe = true;
        twineCoro = StartCoroutine(twine(1f, 1.3f));
        if(safe)
            StartCoroutine(OnTop(true));
    }

    //
    private void OnMouseExit()
    {
        if (!enabled)
            return;
        if (twineCoro != null)
            StopCoroutine(twineCoro);
        twineCoro = StartCoroutine(twine(1.3f, 1.0f));
        if(safe)
            StartCoroutine(OnTop(false));
    }

    IEnumerator twine(float a, float b)
    {
        for (int i = 0; i < 4; i++)
        {
            transform.localScale = Vector3.one * math.remap(0f, 3, a*1.5f, b*1.5f, i);
            yield return null;
        }
    }

    IEnumerator OnTop(bool start)
    {
        if (!start)
        {
             GetComponent<Cast>().StartMoveBack();
             yield break;
        }
        for (int i = 0; i < 4; i++)
        {
            transform.position += new Vector3(0, 1f / 4f, -1 / 4f) ;
            yield return null;
        }
    }
}