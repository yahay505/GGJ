using System;
using System.Collections;
using UnityEngine;

namespace Script
{
    public class BackgroundFade : MonoBehaviour
    {
        private SpriteRenderer[] bgs;

        private void Start()
        {
            StartCoroutine(Fade());
        }

        IEnumerator Fade()
        {
            int bgtime = 0, expectedTime = 0;
            yield return null;
            yield return new WaitUntil(() => FindObjectOfType<CardStateManager>().TurnNo != expectedTime);
            expectedTime = FindObjectOfType<CardStateManager>().TurnNo;
            
        }
        
    }
}