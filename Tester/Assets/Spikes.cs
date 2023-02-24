using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;



public class Spikes : Open
{
    public override void Interact()
    {
        if(isOpen)
        {
            sr.sprite = closed;
        }
        else
        {
            sr.sprite = open;
        }
        isOpen = !isOpen;
    }
}
