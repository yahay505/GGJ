using System.Collections;
using Script;
using Unity.Mathematics;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public bool CanCast = false;
    private void OnMouseUp()
    {
        if (!enabled)
            return;
        var cardStateManager = FindObjectOfType<CardStateManager>();
        if (CanCast)
        {
            cardStateManager.Play(GetComponent<CardHolder>().Card,gameObject);
        }
        else
        {
            StartCoroutine(MoveBack(cardStateManager
                .positions[cardStateManager.GetIndex(gameObject)]));
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!enabled)
            return;
        // Debug.Log(col.tag);
        if(col.CompareTag("CastZone"))
        {
            CanCast = true;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!enabled)
            return;
        // Debug.Log(col.tag);

        if(other.CompareTag("CastZone"))
        {
            CanCast = false;
        }
    }

    public void StartMoveBack()
    {
        var cardStateManager = FindObjectOfType<CardStateManager>();

        StartCoroutine(MoveBack(cardStateManager
            .positions[cardStateManager.GetIndex(gameObject)]));
    }
    private IEnumerator MoveBack(Transform _transform)
    {
        var oldpos = transform.position;
            var newPosition = _transform.position;
            newPosition.z = 0;
        
        for (int i = 0; i < 10; i++)
        {
            var pos=math.remap(0f, 9f, 0, 1, i);
            transform.position=UnityEngine.Vector3.Lerp(oldpos, newPosition, pos);
            yield return null;
        }
    }
}
