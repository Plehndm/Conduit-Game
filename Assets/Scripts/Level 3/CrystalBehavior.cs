using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBehavior : MonoBehaviour
{
    public Material unlit;
    public Material lit;

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<LaserLogic>().Charged)
            GetComponent<MeshRenderer>().material = lit;
        else
            GetComponent<MeshRenderer>().material = unlit;
    }
}
