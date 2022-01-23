using System;
using TMPro;
using UnityEngine;

namespace Script
{
    public class CardHolder : MonoBehaviour
    {
        public Card Card;
        public TextMeshPro Lore, Stats;
        public void Setup()
        {
            GetComponent<SpriteRenderer>().sprite = Card.Image ? Card.Image : GetComponent<SpriteRenderer>().sprite;

            Lore.text = Card.Text;
            Stats.text = Card.IsAction? GenerateActionStat(): GenerateModifierStat();
            if(!Card.IsAction)
                Stats.fontSize = 1.5f;

        }

        private string GenerateActionStat()
        {
            var txt = "";
            if (Card.MoneyEffect!=0)
            {
                txt += "<sprite index= 0>:";
                if (Card.MoneyEffect<0)
                {
                    txt += "<sprite index= 4>";
                    if (Card.MoneyEffect<-1)
                    {
                        txt += "<sprite index= 4>";
                    }

                    if (Card.MoneyEffect < -2)
                    {
                        txt += "<sprite index= 4>";
                    }
                }
                if (Card.MoneyEffect>0)
                {
                    txt += "<sprite index= 2>";
                    if (Card.MoneyEffect>1)
                    {
                        txt += "<sprite index= 2>";
                    }

                    if (Card.MoneyEffect > 2)
                    {
                        txt += "<sprite index= 2>";
                    }
                }

                if (Card.PopularityEffect!=0)
                {
                    txt += "<br>";
                }
            }

            if (Card.PopularityEffect!=0)
            {
                txt += "<sprite index= 1>:";
                if (Card.PopularityEffect<0)
                {
                    txt += "<sprite index= 5>";
                    if (Card.PopularityEffect<-1)
                    {
                        txt += "<sprite index= 5>";
                    }

                    if (Card.PopularityEffect < -2)
                    {
                        txt += "<sprite index= 5>";
                    }
                }
                if (Card.PopularityEffect>0)
                {
                    txt += "<sprite index= 3>";
                    if (Card.PopularityEffect>1)
                    {
                        txt += "<sprite index= 3>";
                    }

                    if (Card.PopularityEffect > 2)
                    {
                        txt += "<sprite index= 3>";
                    }
                }

            }
          
            return txt;
        }

        private string GenerateModifierStat()
        {
            var txt = "";

            #region money

            

            if (Card.x0)
            {
                txt += $"{Card.MoneyInstant}/10<sprite index= 0> now<br>";
            }
            if (Card.x1)
            {
                txt += $"{Card.MoneyPerTurn/10}<sprite index= 0> for {Card.MoneyTurnCount}<sprite index= 6><br>";
            }

            if (Card.x2)
            {
                txt += $"{Card.MoneyMultiplierForDay}x <sprite index= 0> for a day<br>";
            }
            if (Card.x3)
            {
                txt += $"{Card.MoneyMultiplierForXTurns}x <sprite index= 0> for {Card.MoneyMultiplierTurnCount} <sprite index= 6><br>";
            }

            if (Card.x4)
            {
                txt += $"get {Card.MoneyReturnAfterTurn/10} after {Card.MoneyReturnAfterTurnCount} <sprite index= 6><br>";
            }

            if (Card.x5)
            {
                txt += $"{Card.MoneyNextCardGainMultiplier}x<sprite index= 0> for next <sprite index= 6><br>";
            }

            if (Card.x6)
            {
                txt += $"{Card.MoneyNextCardGain / 10}<sprite index= 0> for next <sprite index= 6><br>";
            }
            #endregion

            #region pop

            

            if (Card.y0)
            {
                txt += $"{Card.PopularityInstant}/10<sprite index=01> now<br>";
            }
            if (Card.y1)
            {
                txt += $"{Card.PopularityPerTurn/10}<sprite index=01> for {Card.PopularityTurnCount}<sprite index= 6><br>";
            }

            if (Card.y2)
            {
                txt += $"{Card.PopularityMultiplierForDay}x <sprite index=01> for a day<br>";
            }
            if (Card.y3)
            {
                txt += $"{Card.PopularityMultiplierForXTurns}x <sprite index=01> for {Card.PopularityMultiplierTurnCount} <sprite index= 6><br>";
            }

            if (Card.y4)
            {
                txt += $"get {Card.PopularityReturnAfterTurn/10} after {Card.PopularityReturnAfterTurnCount} <sprite index= 6><br>";
            }

            if (Card.y5)
            {
                txt += $"{Card.PopularityNextCardGainMultiplier}x<sprite index=01> for next <sprite index= 6><br>";
            }

            if (Card.y6)
            {
                txt += $"{Card.PopularityNextCardGain / 10}<sprite index=01> for next <sprite index= 6><br>";
            }


            
            #endregion
            
            return txt;
            
            
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