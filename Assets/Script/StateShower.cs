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
        TextOutput.text =
            (outputMoney ? $"<sprite index= 0> {FindObjectOfType<CardStateManager>().Money.ToString()}" : "") +
            (OutputPop
                ? $"<sprite index= 1> {FindObjectOfType<CardStateManager>().Popularity.ToString()}"
                : "");
    }
}
