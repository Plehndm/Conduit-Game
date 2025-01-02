using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class ArrangeOtherPlanets : MonoBehaviour
{
    [SerializeField] private GameObject[] Planets;
    [SerializeField] private int[] Positions;

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
