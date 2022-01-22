using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Script
{
    public class CardStateManager : MonoBehaviour
    {
        private int TurnNo, DayNo;
        private void Awake()
        {
            Application.targetFrameRate = 30;
        }

        public List<Card> History = new List<Card>();

        public Card[] Deck
        {
            get { return DeckObjects.Select(o => o.GetComponent<CardHolder>().Card).ToArray(); }
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

        public List<effect> MoneyActionEffects = new List<effect>();
        public List<effect> PopActionEffects = new List<effect>();


        public List<effect> MoneyDailyEffects = new List<effect>();
        public List<effect> PopDailyEffects = new List<effect>();

        public List<effect> MoneyTurnEffects = new List<effect>();
        public List<effect> PopTurnEffects = new List<effect>();


        public List<effect> MoneyInvestments = new List<effect>();
        public List<effect> PopInvestments = new List<effect>();
        public void Play(Card card)
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

                TurnNo++;
                if (TurnNo==10)
                {
                    TurnNo = 0;
                    DayNo++;
                }
            }
            Debug.Log($"added {money.ToString()} money and {popularity.ToString()} popularity;");
            //// TODO: add money to counter
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

            MoneyInvestments.ForEach(a => a.TurnLeft--);
            MoneyInvestments.ForEach(a =>
            {
                if (a.TurnLeft==0)
                {
                    Debug.Log($"Investment returned {a.offset.ToString()}");
                    // TODO: add back investment
                }
            });
            MoneyInvestments.RemoveAll(a => a.TurnLeft <= 0);
            if (card.x5)
            {
                MoneyActionEffects.Add(new effect(0,0,card.MoneyNextCardGainMultiplier));
            }

            if (card.x6)
            {
                MoneyActionEffects.Add(new effect(card.MoneyNextCardGain,0));
            }
            
            
            
            
            if (card.y1)
            {
                MoneyTurnEffects.Add(new effect(card.MoneyPerTurn,card.MoneyTurnCount));
            }

            if (card.y2)
            {
                MoneyDailyEffects.Add(new effect(0,0,card.MoneyMultiplierForDay));
            }

            if (card.y3)
            {
                MoneyTurnEffects.Add(new effect(0,card.MoneyMultiplierTurnCount,card.MoneyMultiplierForXTurns));  
            }

            if (card.y4)
            {
                MoneyInvestments.Add(new effect(card.MoneyReturnAfterTurn,card.MoneyReturnAfterTurnCount));
            }

            MoneyInvestments.ForEach(a => a.TurnLeft--);
            MoneyInvestments.ForEach(a =>
            {
                if (a.TurnLeft==0)
                {
                    Debug.Log($"Investment returned {a.offset.ToString()}");
                    // TODO: add back investment
                }
            });
            MoneyInvestments.RemoveAll(a => a.TurnLeft <= 0);
            if (card.y5)
            {
                MoneyActionEffects.Add(new effect(0,0,card.MoneyNextCardGainMultiplier));
            }

            if (card.y6)
            {
                MoneyActionEffects.Add(new effect(card.MoneyNextCardGain,0));
            }

            
            #endregion
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