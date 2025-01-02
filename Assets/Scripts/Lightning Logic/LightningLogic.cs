using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningLogic : MonoBehaviour
{
    [Header("Basic Properties")]
    public bool Charged = false;
    public bool ShouldDischarge = true;
    public bool LightningCanCharge = false;
    public int DischargeDelay = 2;

    public void LightningCharge()
    {
        if(this.LightningCanCharge)
            this.Charge();
    }

    public virtual void Charge()
    {
        Charged = true;
        if(this.ShouldDischarge)
            StartCoroutine(DischargeCoroutine());
    }

    public virtual void Discharge()
    {
        Charged = false;
    }

    public virtual void Activate() {}

    public virtual IEnumerator DischargeCoroutine() 
    {
        yield return new WaitForSeconds(DischargeDelay);
        this.Discharge();
    }
}
