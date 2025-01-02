using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    public TMP_Text dialogue;
    public string input;
    public bool isCheckpoint = true;
    private bool activated = false;

    private void OnTriggerEnter(Collider other) 
    {
        if(!activated && other.CompareTag("Player"))
        {
            if(isCheckpoint)
                manager.SetCheckPoint(this.transform.GetChild(0).transform.position);
            dialogue.SetText(input);
            StartCoroutine(DeleteText());
            activated = true;
        }
    }

    private IEnumerator DeleteText()
    {
        yield return new WaitForSeconds(10f);
        dialogue.SetText("");
    }
}
