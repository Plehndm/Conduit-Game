using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaserLogic : LightningLogic
{
    [SerializeField] private GameObject target;
    [SerializeField] private Material laserMat;
    private LayerMask mask;

    private void Awake() 
    {
        mask = LayerMask.GetMask("Laser Targets");    
    }

    public override void Charge()
    {
        base.Charge();
    }

    public override void Activate()
    {
        if(Charged && target.GetComponent<LightningLogic>().Charged)
            FireLaser();
    }

    private void FireLaser()
    {
        if(target != null)
        {
            Vector3 pos = transform.position;
            RaycastHit laser;

            if(Physics.Raycast(pos, pos - target.transform.position, out laser, Mathf.Infinity, mask))
            {
                LineRenderer laserBeam = gameObject.AddComponent<LineRenderer>();
                laserBeam.material = laserMat;
                laserBeam.widthMultiplier = 0.8f;
                laserBeam.positionCount = 2;
                laserBeam.SetPosition(0, pos);
                laserBeam.SetPosition(1, laser.point);
                target.GetComponent<LightningLogic>().Charge();
            }
        }
    }
}
