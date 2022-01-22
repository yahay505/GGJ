﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace Script
{
    public class CardStateManager : MonoBehaviour
    {
        public int TurnNo, DayNo;
        public int Popularity, Money;
        public GameObject CardPrefab;
        public Transform CardStartPoint;
        private void Awake()
        {
            Application.targetFrameRate = 30;
            for (int i = 0; i < 5; i++)
            {
                CreateCard(i, out var card);
            }
        }

        private void Start()
        {
            // throw new NotImplementedException();
        }

        public List<Card> History = new List<Card>();

        public Card[] Deck
        {
            get { return DeckObjects.Select(o => o.GetComponent<CardHolder>()?.Card).ToArray(); }
        }

        public GameObject[] DeckObjects = new GameObject[] {null, null, null, null, null};
        public Transform[] positions = new Transform[5];

        public int GetIndex(GameObject o)
        {
            for (int i = 0; i < DeckObjects.Length; i++)
            {
                if (o == DeckObjects[i])
                {
                    return i;
                }
            }

            return -1;
        }

        private void Update()
        {
            ;
            // throw new NotImplementedException();
        }

        public List<effect> MoneyActionEffects = new List<effect>();
        public List<effect> PopActionEffects = new List<effect>();


        public List<effect> MoneyDailyEffects = new List<effect>();
        public List<effect> PopDailyEffects = new List<effect>();

        public List<effect> MoneyTurnEffects = new List<effect>();
        public List<effect> PopTurnEffects = new List<effect>();


        public List<effect> MoneyInvestments = new List<effect>();
        public List<effect> PopInvestments = new List<effect>();
        public void Play(Card card,GameObject cardObject)
        {
            #region evaluate

            int money = card.MoneyInstant, popularity = card.PopularityInstant;
            if (card.IsAction)
            {
                foreach (var effect in MoneyActionEffects)
                {
                    money += effect.offset;
                    money = (int) (money * effect.multiplier);
                }

                foreach (var effect in PopActionEffects)
                {
                    popularity += effect.offset;
                    popularity = (int) (popularity * effect.multiplier);
                }

                MoneyActionEffects = new List<effect>();
                PopActionEffects = new List<effect>();


                foreach (var effect in MoneyDailyEffects)
                {
                    money += effect.offset;
                    money = (int) (money * effect.multiplier);
                }

                foreach (var effect in PopDailyEffects)
                {
                    popularity += effect.offset;
                    popularity = (int) (popularity * effect.multiplier);
                }

                MoneyTurnEffects.RemoveAll(a => a.TurnLeft <= 0);
                foreach (var effect in MoneyTurnEffects)
                {
                    effect.TurnLeft--;
                    money += effect.offset;
                    money = (int) (money * effect.multiplier);
                }

                PopTurnEffects.RemoveAll(a => a.TurnLeft <= 0);
                foreach (var effect in PopTurnEffects)
                {
                    effect.TurnLeft--;
                    money += effect.offset;
                    money = (int) (money * effect.multiplier);
                }   
                #region moveturn
                TurnNo++;
                if (TurnNo==10)
                {
                    TurnNo = 0;
                    DayNo++;
                }
                MoneyInvestments.ForEach(a => a.TurnLeft--);
                MoneyInvestments.ForEach(a =>
                {
                    if (a.TurnLeft==0)
                    {
                        Debug.Log($"Investment returned {a.offset.ToString()}");
                        Money += a.offset;
                    }
                });
                MoneyInvestments.RemoveAll(a => a.TurnLeft <= 0);
                #endregion
            }
            Debug.Log($"added {money.ToString()} money and {popularity.ToString()} popularity;\n" +
                      $"");
            Money += money;
            Popularity += popularity;
            if (card.x1)
            {
                MoneyTurnEffects.Add(new effect(card.MoneyPerTurn,card.MoneyTurnCount));
            }

            if (card.x2)
            {
                MoneyDailyEffects.Add(new effect(0,0,card.MoneyMultiplierForDay));
            }

            if (card.x3)
            {
                MoneyTurnEffects.Add(new effect(0,card.MoneyMultiplierTurnCount,card.MoneyMultiplierForXTurns));  
            }

            if (card.x4)
            {
                MoneyInvestments.Add(new effect(card.MoneyReturnAfterTurn,card.MoneyReturnAfterTurnCount));
            }


            if (card.x5)
            {
                MoneyActionEffects.Add(new effect(0,0,card.MoneyNextCardGainMultiplier));
            }

            if (card.x6)
            {
                MoneyActionEffects.Add(new effect(card.MoneyNextCardGain,0));
            }
            
            #region pop
            
            
            if (card.y1)
            {
                PopTurnEffects.Add(new effect(card.PopularityPerTurn,card.PopularityTurnCount));
            }

            if (card.y2)
            {
                PopDailyEffects.Add(new effect(0,0,card.PopularityMultiplierForDay));
            }

            if (card.y3)
            {
                PopTurnEffects.Add(new effect(0,card.PopularityMultiplierTurnCount,card.PopularityMultiplierForXTurns));  
            }

            if (card.y4)
            {
                PopInvestments.Add(new effect(card.PopularityReturnAfterTurn,card.PopularityReturnAfterTurnCount));
            }

            PopInvestments.ForEach(a => a.TurnLeft--);
            PopInvestments.ForEach(a =>
            {
                if (a.TurnLeft==0)
                {
                    Debug.Log($"Investment returned {a.offset.ToString()}");
                    Popularity += a.offset;
                }
            });
            PopInvestments.RemoveAll(a => a.TurnLeft <= 0);
            if (card.y5)
            {
                PopActionEffects.Add(new effect(0,0,card.PopularityNextCardGainMultiplier));
            }

            if (card.y6)
            {
                PopActionEffects.Add(new effect(card.PopularityNextCardGain,0));
            }

            #endregion
            #endregion

            #region handleOldCard

            History.Add(card);
            cardObject.GetComponent<DragnDrop>().enabled = false;
            cardObject.GetComponent<Cast>().enabled = false;
            // Do Animation
            // TODO remove
            //temporary
            StartCoroutine(die(cardObject));
            //
            //
            var index = GetIndex(cardObject);
            DeckObjects[index] = null;
            

            #endregion


            CreateCard(index, out var newcard);

            IEnumerator die(GameObject cardObject)
            {
                Color color = cardObject.GetComponent<SpriteRenderer>().color;
                for (int i = 0; i < 15; i++)
                {
                    color.a = math.remap(0,14,1,0,i);
                    cardObject.GetComponent<SpriteRenderer>().color = color;
                    yield return null;
                }
                Destroy(cardObject);
            }
        }

        private void CreateCard(int index, out GameObject newcard)
        {
            newcard = Instantiate(CardPrefab, CardStartPoint.position, CardStartPoint.rotation, null);
            newcard.GetComponent<CardHolder>().Card = FindObjectOfType<CardList>().GetRandomCard();
            DeckObjects[index] = newcard;
            newcard.GetComponent<CardHolder>().Setup();
            newcard.GetComponent<Cast>().StartMoveBack();
        }

        public class effect
        {
            public float multiplier;
            public int offset;
            public int TurnLeft;

            public effect(int _offset, int turnLeft, float _multiplier = 1)
            {
                multiplier = _multiplier;
                offset = _offset;
                TurnLeft = turnLeft;
            }
        }
    }
}