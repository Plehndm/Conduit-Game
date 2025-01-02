using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : LightningLogic
{
    [SerializeField] private GameManager manager;
    [SerializeField] private GameObject player;

    public override void Charge()
    {
        GetComponentInParent<PlayerController>().PlayerDeath();
        StartCoroutine(manager.DeathAnim());
    }
}
