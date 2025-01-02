using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerLogic : LinkLightning
{
    [Header("Partner Properties")]
    [SerializeField] private PartnerLogic LogicPartner;
    public bool isSender;

    public override int CheckCondition()
    {
        if(LogicPartner.isSender && LogicPartner.Charged)
            return 0;
        else 
            return breakVal;
    }

    void OnValidate () {
        if (LogicPartner != null) {
            LogicPartner.LogicPartner = this;
        }
    }
}
