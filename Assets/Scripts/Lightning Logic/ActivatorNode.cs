using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorNode : LightningLogic
{
    public LightningLogic[] LogicToActivate;

    public override void Charge()
    {
        base.Charge();
        foreach(LightningLogic logic in LogicToActivate)
            logic.Activate();
        StartCoroutine(DischargeCoroutine());
    }
}
