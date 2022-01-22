using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource SFX, SoundTrack;
    public AudioClip[] music,SFXClipls;

    public void PlaySFX(SFXs sfx)
    {
        SFX.PlayOneShot(SFXClipls[(int)sfx]);
    }

    public void PlayMusic()
    {
        
    }

    public enum SFXs
    {
        
    }

    public enum musics
    {
        cardSelect,
        cardpickup,
        cardDrop,
    }
}
