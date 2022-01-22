using System.Collections;
using System.Collections.Generic;
using Script;
using TMPro;
using UnityEngine;

public class StateShower : MonoBehaviour
{
    public TextMeshPro TextOutput;

    public bool outputMoney, OutputPop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var popularity = FindObjectOfType<CardStateManager>().Popularity/10;
        var money = FindObjectOfType<CardStateManager>().Money/10;
        TextOutput.text =
            (outputMoney ? $"<sprite index= 0> {money.ToString()}" : "") +
            (OutputPop
                ? $"<br><sprite index= 1> {popularity.ToString()}"
                : "");
    }
}
