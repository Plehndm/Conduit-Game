using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PortalStartAnimation : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private LightningLogic activator;

    private void Start() 
    {
        transform.localScale = new Vector3(0, 0, 0);
        GetComponentInChildren<VisualEffect>().enabled = false;
    }

    private void Update() 
    {
        if(activator.Charged == true)
        {
            StartAnim();
        }
    }

    public void StartAnim()
    {
        GetComponentInChildren<VisualEffect>().enabled = true;
        StartCoroutine(Anim());
    }

    private IEnumerator Anim()
    {
        yield return new WaitForSeconds(1);
        while(transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(speed, speed, speed);
            yield return new WaitForEndOfFrame();
        }
    }
}
