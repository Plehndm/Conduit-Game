using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkLightning : LightningLogic
{
    [Header("Link Properties")]
    public LightningLogic[] LinkedLogic;
    public readonly int breakVal = -1;

    public override void Charge()
    {
        base.Charge();
        int index = CheckCondition();
        if(index >= 0 && index < LinkedLogic.Length)
            LinkedLogic[index].Charge();
    }

    public override void Discharge()
    {
        base.Discharge();
        foreach(LightningLogic logic in LinkedLogic)
            if(logic.ShouldDischarge)
                logic.Discharge();
    }

    public virtual int CheckCondition()
    {
        return 0;
    }

}
