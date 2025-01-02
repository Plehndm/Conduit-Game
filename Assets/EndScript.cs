using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public LightningLogic logic;
    public GameObject gamePanel;

    // Update is called once per frame
    void Update()
    {
        if(logic.Charged)
        {
            gamePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
