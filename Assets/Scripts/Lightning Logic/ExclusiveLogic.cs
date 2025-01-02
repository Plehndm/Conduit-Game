using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExclusiveLogic : LinkLightning
{
    [Header("Partner Properties")]
    [SerializeField] private ExclusiveLogic LogicPartner;
    public bool isActive = false;

    public override int CheckCondition()
    {
        if(this.isActive)
            return 0;
        else
            return breakVal;
    }

    public override void Activate()
    {
        isActive = !isActive;
    }

    void OnValidate () {
        if (LogicPartner != null) {
            LogicPartner.LogicPartner = this;
        }
    }
}
