using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class RotationalLock : LinkLightning
{
    [Header("Rotational Properties")]
    [SerializeField][Range(0, 7)] private int[] Rotations;
    [SerializeField][Range(0, 7)] private int currentRotation = 0;
    [SerializeField] private GameObject itemToRotate;

    public override int CheckCondition()
    {
        return Array.IndexOf(Rotations, currentRotation);
    }

    public override void Activate()
    {
        currentRotation++;
        if(currentRotation > 8)
            currentRotation = 0;
        itemToRotate.transform.Rotate(0, (360 / 8), 0);
    }
}
