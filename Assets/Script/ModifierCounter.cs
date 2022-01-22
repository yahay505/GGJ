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
        txt += "Daily:<br>";
        float multip=1;
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
        
        foreach (var effect in FindObjectOfType<CardStateManager>().MoneyTurnEffects)
        {
            txt += $"{effect.multiplier}x <sprite index= 0><br> for {effect.TurnLeft} <sprite index= 6>";
        }
        foreach (var effect in FindObjectOfType<CardStateManager>().PopTurnEffects)
        {
            txt += $"{effect.multiplier}x <sprite index= 1><br> for {effect.TurnLeft} <sprite index= 6>";
        }
        multip = 1;
        foreach (var effect in FindObjectOfType<CardStateManager>().MoneyActionEffects)
        {
            multip *= effect.multiplier;
        }

        
        
        
    }
}
