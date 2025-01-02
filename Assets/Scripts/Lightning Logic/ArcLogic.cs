using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ArcLogic : MonoBehaviour
{
    [SerializeField] private LightningLogic logic1;
    [SerializeField] private LightningLogic logic2;
    
    void Update()
    {
        if(logic1.Charged && logic2.Charged) 
        {
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<VisualEffect>().enabled = true;
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<VisualEffect>().enabled = true;
            gameObject.transform.GetChild(0).GetChild(2).GetComponent<VisualEffect>().enabled = true;
        }
        else
        {
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<VisualEffect>().enabled = false;
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<VisualEffect>().enabled = false;
            gameObject.transform.GetChild(0).GetChild(2).GetComponent<VisualEffect>().enabled = false;
        }
    }
}
