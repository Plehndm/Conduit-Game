using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehavior : MonoBehaviour
{
    [SerializeField] private Material normalMat;
    [SerializeField] private Material glowMat;
    private GameObject rune;
    private LightningLogic logic;

    void Start()
    {
        rune = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        logic = GetComponentInChildren<LightningLogic>();
        transform.rotation = Quaternion.Euler(0, Random.rotation.y * 360, 0);
    }

    void Update()
    {
        if(logic.Charged)
            rune.GetComponent<MeshRenderer>().material = glowMat;
        else 
            rune.GetComponent<MeshRenderer>().material = normalMat;
    }
}
