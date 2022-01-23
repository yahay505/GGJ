using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SoundOnMouseDown : MonoBehaviour
{
    private void OnMouseDown()
    {
        FindObjectOfType<SoundManager>().PlaySFX(SoundManager.SFXs.cardpickup);
    }
}
