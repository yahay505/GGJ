using System;
using UnityEngine;

namespace Script
{
    public class CardHolder : MonoBehaviour
    {
        public Card Card;

        public void Setup()
        {
            
        }

        public void AddToDeck(GameObject o)
        {
            var deckObjects = FindObjectOfType<CardStateManager>().DeckObjects;
            for (int i = 0; i < deckObjects.Length; i++)
            {
                if (deckObjects[i]==null)
                {
                    deckObjects[i] = o;
                    return;
                }
            }
            throw new IndexOutOfRangeException("Deck Already Full");
        }
    }
}