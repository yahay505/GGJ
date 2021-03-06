using System.Collections;
using System.Collections.Generic;
using Script;
using TMPro;
using UnityEngine;

public class ModifierCounter : MonoBehaviour
{
    public TextMeshPro TextOutput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var txt = "";
        txt += $"Daily:({10-FindObjectOfType<CardStateManager>().TurnNo} <sprite index= 6> left)<br>";
        float multip=1;

        #region Daily

        

        foreach (var effect in FindObjectOfType<CardStateManager>().MoneyDailyEffects)
        {
            multip *= effect.multiplier;
        }

        if (multip!=1)
        {
            txt += $"{multip}x <sprite index= 0><br>";
        }

        multip = 1;
        foreach (var effect in FindObjectOfType<CardStateManager>().PopDailyEffects)
        {
            multip *= effect.multiplier;
        }

        if (multip!=1)
        {
            txt += $"{multip}x <sprite index= 1><br>";
        }
        #endregion

        #region TurnEffects
        txt += "For Turns:<br>";

        

        foreach (var effect in FindObjectOfType<CardStateManager>().MoneyTurnEffects)
        {
            txt += $"{effect.multiplier}x <sprite index= 0> for {effect.TurnLeft} <sprite index= 6><br>";
        }
        foreach (var effect in FindObjectOfType<CardStateManager>().PopTurnEffects)
        {
            txt += $"{effect.multiplier}x <sprite index= 1> for {effect.TurnLeft} <sprite index= 6><br>";
        }
        #endregion

        #region Action

        txt += "Next Card: <br>";

        multip = 1;
        foreach (var effect in FindObjectOfType<CardStateManager>().MoneyActionEffects)
        {
            multip *= effect.multiplier;
        }
        if (multip!=1)
        {
            txt += $"{multip}x <sprite index= 1><br>";
        } 
        multip = 1;
        foreach (var effect in FindObjectOfType<CardStateManager>().PopActionEffects)
        {
            multip *= effect.multiplier;
        }
        if (multip!=1)
        {
            txt += $"{multip}x <sprite index= 1><br>";
        }

            #endregion

            TextOutput.text = txt;



    }
}
