using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalManager : LightningLogic
{
    [SerializeField] private LightningLogic[] Rings;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void UpdateRotationChecks()
    {
        bool successful = true;
        for(int i = 0; i < Rings.Length;)
            if(!Rings[i].Charged)
                successful = false;
        
        if(successful)
            this.Charge();
    }

    public void RotateSound()
    {
        source.Stop();
        source.Play();
    }
}
