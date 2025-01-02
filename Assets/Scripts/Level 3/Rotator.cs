using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : LightningLogic
{
    [SerializeField][Range(0, 7)] private int rotation = 0;
    [SerializeField][Range(0, 7)] private int targetRot;
    [SerializeField] private RotationalManager manager;
    [SerializeField] private LaserLogic laser;

    private void Start()
    {
        // transform.rotation = Quaternion.Euler(0, Mathf.Round((Random.value * 360) / 45) * 45, 0);
        // rotation = (int) Mathf.Floor(transform.rotation.y / 45);
    }

    public override void Activate()
    {
        rotation++;
        manager.RotateSound();
        if(rotation > 7)
            rotation = 0;
        transform.Rotate(0, 45, 0);
        
        if(rotation == targetRot)
        {
            this.Charge();
            laser.Activate();
            // manager.UpdateRotationChecks();
        }
        else
            this.Charged = false;
    }
}
