using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Script
{
    public class CardStateManager : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 30;
        }

        public List<Card> History=new List<Card>();
    public Card[] Deck
    {
        get { return DeckObjects.Select(o => o.GetComponent<CardHolder>().Card).ToArray(); }
    }
    public GameObject[] DeckObjects = new GameObject[]{null,null,null,null,null};
    public Transform[] positions = new Transform[5];

    public int GetIndex(GameObject o)
    {
        for (int i = 0; i < DeckObjects.Length; i++)
        {
            if (o==DeckObjects[i])
            {
                return i;
            }
        }

        return -1;
    }
    #region NextCardEffects

    public float MoneyNextCardMultiplier = 1;

    #endregion 
    public void Play(Card card)
    {
        
    }
    }
}