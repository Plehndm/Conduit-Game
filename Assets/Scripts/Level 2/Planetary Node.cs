using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryNode : LightningLogic
{
    [SerializeField] private PlanetaryManager manager;
    [SerializeField] private GameObject planet;

    private void Start() 
    {
        LightningCanCharge = true;
    }

    public override void Charge()
    {
        base.Charge();
        manager.SwitchPlanet(planet);
    }
}
