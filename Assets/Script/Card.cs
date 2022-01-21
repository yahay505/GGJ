using UnityEngine;

namespace Script
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Create Card", order = 0)]
    public class Card : ScriptableObject
    {
        public Sprite Image;
        public string Text;
        public bool IsAction;
        public int MoneyEffect, PopularityEffect;
        #region effects

        #region money

        public bool x0;
        public int MoneyInstant;
        
        public bool x1;
        public int MoneyPerTurn,MoneyTurnCount;
        
        public bool x2;
        public float MoneyMultiplierForDay=1;
        
        public bool x3;
        public float MoneyMultiplierForXTurns;
        public int MoneyMultiplierTurnCount;

        public bool x4;
        public int MoneyReturnAfterTurn, MoneyReturnAfterTurnCount;

        public bool x5;
        public float MoneyNextCardGainMultiplier;
        
        public bool x6;
        public int MoneyNextCardGain;

        #endregion


        #region Popularity
        
        public int PopularityInstant;
        public int PopularityPerTurn,PopularityTurnCount;
        public float PopularityMultiplierForDay;
        
        public float PopularityMultiplierForXTurns;
        public int PopularityMultiplierTurnCount;

        public int PopularityReturnAfterTurn, PopularityReturnAfterTurnCount;

        public float PopularityNextCardGainMultiplier;
        public int PopularityNextCardGain;


        #endregion
        #endregion
    }
}