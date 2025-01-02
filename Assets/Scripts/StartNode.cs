using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private BoxCollider playerTrigger;

    public int initialDelay = 2;
    private bool canActivate = true;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && canActivate)
            StartCoroutine(Activate());
    }

    private IEnumerator Activate()
    {
        canActivate = false;
        yield return new WaitForSeconds(initialDelay);
        gameManager.SummonOneLightning(transform.position);
        gameManager.EnableLightning();
        yield return new WaitForSeconds(0.5f);
        playerTrigger.enabled = true;
    }
}
