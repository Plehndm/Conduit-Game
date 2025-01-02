using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.UIElements;

public class PlanetaryManager : LightningLogic
{
    [SerializeField] private GameObject SelectedPlanet;
    [SerializeField] private GameObject[] PlanetsInOrder; 
    [SerializeField] private LightningLogic ChargeNode;
    [SerializeField] private GameObject LightningArc;
    public Material normalMat;
    public Material glowMat;
    [SerializeField] private int currentIndex = 1;
    [SerializeField] private float minimumDistance = 5f;
    private PlanetBehavior behavior;
    private AudioSource audioSource;

    [Header("Positions for Planets")]
    [SerializeField] private GameObject[] Planets;
    [SerializeField][Range(0, 1)] private float[] Positions;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        behavior = SelectedPlanet.GetComponent<PlanetBehavior>();
        behavior.Select();
    }

    private void Update()
    {
        if(currentIndex >= PlanetsInOrder.Length)
        {
            Arrange();
            this.Charge();
        }

        GameObject movingPlanet = PlanetsInOrder[currentIndex - 1];
        GameObject nextPlanet = PlanetsInOrder[currentIndex];

        Vector3 pos1 = movingPlanet.transform.position;
        Vector3 pos2 = nextPlanet.transform.position;
        float dist = Vector3.Distance(pos1, pos2);

        if(dist <= minimumDistance)
        {
            LightningArc.transform.GetChild(1).transform.position = pos1;
            LightningArc.transform.GetChild(4).transform.position = pos2;
            LightningArc.transform.GetChild(2).transform.position = Vector3.Lerp(pos1, pos2, 0.5f);
            LightningArc.transform.GetChild(3).transform.position = Vector3.Lerp(pos1, pos2, 0.5f);
            if(LightningArc.activeSelf == false)
                LightningArc.SetActive(true);
        }
        else if(LightningArc.activeSelf == true)
            LightningArc.SetActive(false);
    }

    public void SwitchPlanet(GameObject planet)
    {
        behavior.Deselect();
        SelectedPlanet = planet;
        behavior = planet.GetComponent<PlanetBehavior>();
        behavior.Select();
    }

    public void ChargePlanet()
    {
        if(this.SelectedPlanet == PlanetsInOrder[currentIndex] && ChargeNode.Charged)
        {
            behavior.Charge();
            currentIndex++;
            ChargeNode.Discharge();
            audioSource.Play();
            PlanetsInOrder[currentIndex - 1].GetComponent<PlanetBehavior>().Triggered();
        }
    }

    public void Arrange()
    {
        for(int i = 0; i < Planets.Length;)
        {
            Planets[i].GetComponent<SplineFollower>().enabled = false;

            SplinePositioner positioner = Planets[i].GetComponent<SplinePositioner>();
            positioner.enabled = true;
            positioner.SetPercent(Positions[i]);
        }
    }
}
