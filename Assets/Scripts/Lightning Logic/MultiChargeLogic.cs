using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiChargeLogic : LinkLightning
{
    public override void Charge()
    {
        base.Charge();
        LinkedLogic[1].Charge();
    }
    
}
