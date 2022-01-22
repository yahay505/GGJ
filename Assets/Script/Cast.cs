using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using Unity.Mathematics;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public bool CanCast = false;
    private void OnMouseUp()
    {
        var cardStateManager = FindObjectOfType<CardStateManager>();
        if (CanCast)
        {
            cardStateManager.Play(GetComponent<CardHolder>().Card);
        }
        else
        {
            StartCoroutine(MoveBack(cardStateManager
                .positions[cardStateManager.GetIndex(gameObject)]));
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log(col.tag);
        if(col.CompareTag("CastZone"))
        {
            CanCast = true;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log(col.tag);

        if(other.CompareTag("CastZone"))
        {
            CanCast = false;
        }
    }

    private IEnumerator MoveBack(Transform _transform)
    {
        for (int i = 0; i < 30; i++)
        {
            var pos=math.remap(0f, 29f, 0, 1, i);
            Vector3.Lerp(transform.position, _transform.position, pos);
            yield return null;
        }
    }
}
