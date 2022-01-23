using System;
using System.Collections;
using UnityEngine;

namespace Script
{
    public class CityGrowth : MonoBehaviour
    {
        public  int[] thresholds;
        public GameObject[] cities;

        private void Start()
        {
            StartCoroutine(grow());
        }

        IEnumerator grow()
        {
            while (true)
            {
                var money = FindObjectOfType<CardStateManager>().Money;
                int a;
                foreach (var city in cities)
                {
                    city.SetActive(false);
                }

                a = 0;
                if (money>thresholds[0])
                {
                    a = 1;
                }

                if (money>thresholds[1])
                {
                    a = 2;
                }               
                if (money>thresholds[2])
                {
                    a = 3;
                }
                cities[a].SetActive(true);
                yield return new WaitUntil(() => money != FindObjectOfType<CardStateManager>().Money);
            }
        }
    }
}