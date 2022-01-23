using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Script
{
    public class BackgroundFade : MonoBehaviour
    {
        public SpriteRenderer[] bgs;

        private void Start()
        {
            StartCoroutine(Fade());
        }

        IEnumerator Fade()
        {
            int bgtime = 0, expectedTime = 0;
            yield return null;
            while (true)
            {
                
            switch (expectedTime)
            {
                case 0:
                    StartCoroutine(DoFade(bgs[0], 1f,()=>fulla(bgs[4])));
                    break;
                case 1:
                    StartCoroutine(DoFade(bgs[1], .5f));
                    // StartCoroutine()
                    break;
                case 2:
                    StartCoroutine(DoFade(bgs[1], 1f,()=>fulla(bgs[0])));
                    break;
                case 3:
                    StartCoroutine(DoFade(bgs[2], .5f));
                    break;
                case 4:
                    StartCoroutine(DoFade(bgs[2], 1, () => fulla(bgs[1])));
                    break;
                case 5:
                    StartCoroutine(DoFade(bgs[3], .5f));
                    break;
                case 6:
                    StartCoroutine(DoFade(bgs[3], 1, () => fulla(bgs[2])));
                    break;
                case 7:
                    StartCoroutine(DoFade(bgs[4], .5f));
                    break;
                case 8:
                    StartCoroutine(DoFade(bgs[4], 1, () => fulla(bgs[3])));
                    break;
                case 9:
                    StartCoroutine(DoFade(bgs[0], .5f));
                    break;
            }

            yield return new WaitUntil(() => FindObjectOfType<CardStateManager>().TurnNo != expectedTime);
            expectedTime = FindObjectOfType<CardStateManager>().TurnNo;

            }
        }

        void fulla(SpriteRenderer renderer)
        {
            StartCoroutine(DoFade(renderer, 0));
        }
        IEnumerator DoFade(SpriteRenderer renderer, float to,Action callback=null)
        {
            var curr = renderer.color.a;
            var color = renderer.color;
            for (int i = 0; i < 30; i++)
            {
                color.a = math.remap(0, 29, curr, to, i);
                renderer.color = color;
                yield return null;
            }
            callback?.Invoke();
        }
        
    }
}