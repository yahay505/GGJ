using System.Reflection.Emit;
using UnityEditor;
using UnityEngine;

namespace Script.Editor
{
    [CustomEditor(typeof(Card))]
    public class CardInspector : UnityEditor.Editor
    {
        private bool x,y;
        public override void OnInspectorGUI()
        {
            var card=(Card) target;
            card.Image = (Sprite) EditorGUILayout.ObjectField("Sprite",card.Image, typeof(Sprite), false);
            EditorGUILayout.LabelField("Text info:");
            card.Text = EditorGUILayout.TextArea(card.Text);

            card.IsAction = EditorGUILayout.Toggle("Is Action", card.IsAction);
            card.MoneyEffect = EditorGUILayout.IntField("Effect on money (-3,3)", card.MoneyEffect);
            card.PopularityEffect = EditorGUILayout.IntField("Effect on popularity (-3,3)", card.PopularityEffect);
            
            x = EditorGUILayout.Toggle("use Money", x);

            if (x)
            {
                
                card.x0 = EditorGUILayout.Toggle("Has Instant Money", card.x0);
                if  (card.x0)
                {
                    card.MoneyInstant = EditorGUILayout.IntField("amount", card.MoneyInstant);
                }

                card.x1 = EditorGUILayout.Toggle("Has Money Per Turn", card.x1);
                if  (card.x1)
                {
                    card.MoneyPerTurn = EditorGUILayout.IntField("amount", card.MoneyPerTurn);
                    card.MoneyTurnCount = EditorGUILayout.IntField("turns", card.MoneyTurnCount);
                }
                
                card.x2 = EditorGUILayout.Toggle("Has Daily Money Multiplier", card.x2);
                if  (card.x2) 
                {
                    card.MoneyMultiplierForDay = EditorGUILayout.FloatField("amount", card.MoneyMultiplierForDay);
                }
                
                card.x3 = EditorGUILayout.Toggle("Has Money Multiplier for turn", card.x3);
                if  (card.x3) 
                {
                    card.MoneyMultiplierForXTurns = EditorGUILayout.FloatField("amount", card.MoneyMultiplierForXTurns);
                    card.MoneyMultiplierTurnCount = EditorGUILayout.IntField("turns", card.MoneyMultiplierTurnCount);

                }
                
                card.x4 = EditorGUILayout.Toggle("Has Money Return After Turn", card.x4);
                if  (card.x4) 
                {
                    card.MoneyReturnAfterTurn = EditorGUILayout.IntField("amount", card.MoneyReturnAfterTurn);
                    card.MoneyReturnAfterTurnCount = EditorGUILayout.IntField("turn", card.MoneyReturnAfterTurnCount);
                }            
                
                card.x5 = EditorGUILayout.Toggle("Has Money multiplier for next action", card.x5);
                if  (card.x5) 
                {
                    card.MoneyNextCardGainMultiplier = EditorGUILayout.FloatField("amount", card.MoneyNextCardGainMultiplier);
                }

                card.x6 = EditorGUILayout.Toggle("Has Money Gain on next action", card.x6);
                if  (card.x6) 
                {
                    card.MoneyNextCardGain = EditorGUILayout.IntField("amount", card.MoneyNextCardGain);
                }
            }
            y = EditorGUILayout.Toggle("use Popularity", y);

            if (y)
            {
                
                card.x0 = EditorGUILayout.Toggle("Has Instant Popularity", card.x0);
                if  (card.x0)
                {
                    card.PopularityInstant = EditorGUILayout.IntField("amount", card.PopularityInstant);
                }

                card.x1 = EditorGUILayout.Toggle("Has Popularity Per Turn", card.x1);
                if  (card.x1)
                {
                    card.PopularityPerTurn = EditorGUILayout.IntField("amount", card.PopularityPerTurn);
                    card.PopularityTurnCount = EditorGUILayout.IntField("turns", card.PopularityTurnCount);
                }
                
                card.x2 = EditorGUILayout.Toggle("Has Daily Popularity Multiplier", card.x2);
                if  (card.x2) 
                {
                    card.PopularityMultiplierForDay = EditorGUILayout.FloatField("amount", card.PopularityMultiplierForDay);
                }
                
                card.x3 = EditorGUILayout.Toggle("Has Popularity Multiplier for turn", card.x3);
                if  (card.x3) 
                {
                    card.PopularityMultiplierForXTurns = EditorGUILayout.FloatField("amount", card.PopularityMultiplierForXTurns);
                    card.PopularityMultiplierTurnCount = EditorGUILayout.IntField("turns", card.PopularityMultiplierTurnCount);

                }
                
                card.x4 = EditorGUILayout.Toggle("Has Popularity Return After Turn", card.x4);
                if  (card.x4) 
                {
                    card.PopularityReturnAfterTurn = EditorGUILayout.IntField("amount", card.PopularityReturnAfterTurn);
                    card.PopularityReturnAfterTurnCount = EditorGUILayout.IntField("turn", card.PopularityReturnAfterTurnCount);
                }            
                
                card.x5 = EditorGUILayout.Toggle("Has Popularity multiplier for next action", card.x5);
                if  (card.x5) 
                {
                    card.PopularityNextCardGainMultiplier = EditorGUILayout.FloatField("amount", card.PopularityNextCardGainMultiplier);
                }

                card.x6 = EditorGUILayout.Toggle("Has Popularity Gain on next action", card.x6);
                if  (card.x6) 
                {
                    card.PopularityNextCardGain = EditorGUILayout.IntField("amount", card.PopularityNextCardGain);
                }
            }

            
            // base.OnInspectorGUI();
        }
    }
}