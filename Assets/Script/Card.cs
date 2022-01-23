using UnityEngine;

namespace Script
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Create Card", order = 0)]
    public class Card : ScriptableObject
    {
        public Sprite Image;
        public Texture AlphaMap;
        public string Text;
        public bool IsAction, useMoney,usePop;
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
       
        public bool y0;
        public int PopularityInstant;
        public bool y1;
        public int PopularityPerTurn,PopularityTurnCount;
        public bool y2;
        public float PopularityMultiplierForDay;
        
        public bool y3;
        public float PopularityMultiplierForXTurns;
        public int PopularityMultiplierTurnCount;

        public bool y4;
        public int PopularityReturnAfterTurn, PopularityReturnAfterTurnCount;
        public bool y5;
        public float PopularityNextCardGainMultiplier;
        public bool y6;
        public int PopularityNextCardGain;


        #endregion
        #endregion
    }
}