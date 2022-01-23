using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SoundOnMouseEnter : MonoBehaviour
{
    private void OnMouseEnter()
    {
        FindObjectOfType<SoundManager>().PlaySFX(SoundManager.SFXs.cardHover);
    }
}
