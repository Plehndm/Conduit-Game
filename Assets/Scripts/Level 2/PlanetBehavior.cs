using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class PlanetBehavior : MonoBehaviour
{
    [SerializeField] private PlanetaryManager manager;
    [SerializeField] private bool selected = false;
    [SerializeField] private GameObject rune;
    private Material normalMat;
    private Material glowMat;
    public bool moving = false;
    private bool hasTriggered = false;
    // [SerializeField] private float targetHeight;
    // private float dropSpeed = 3f;

    void Start()
    {
        normalMat = manager.normalMat;
        glowMat = manager.glowMat;
        if(!moving)
            GetComponent<SplineFollower>().enabled = false;
    }

    public void PassedTrigger()
    {
        if(!hasTriggered)
            manager.ChargePlanet();
    }

    public void Charge()
    {
        GetComponent<SplineFollower>().enabled = true;
        moving = true;
    }

    public void Triggered()
    {
        this.hasTriggered = true;
    }

    // private IEnumerator DropAnimation()
    // {
    //     while(transform.position.y > targetHeight)
    //     {
    //         transform.Translate(Vector3.down * Time.deltaTime * dropSpeed);
    //         yield return new WaitForSeconds(0.1f);
    //     }
    // }

    public void Select()
    {
        this.selected = true;
        rune.GetComponent<MeshRenderer>().material = glowMat;
    }

    public void Deselect()
    {
        this.selected = false;
        rune.GetComponent<MeshRenderer>().material = normalMat;
    }
}
