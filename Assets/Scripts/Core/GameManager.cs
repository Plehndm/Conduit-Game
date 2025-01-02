using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    /*public GameObject playScreen;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public Canvas firstPersonCanvas;
    public GameObject titleScreen;
    public GameObject gameSettings;
    public GameObject pauseScreen;
    public Button restartButton;*/
    public GameObject Player;
    public GameObject LightningObject;
    private AudioSource source;
    public AudioClip thunderRumble;
    public AudioClip thunderStrike;

    public bool Paused;
    public bool IsGameActive = false;
    public bool ActivateLightningOnStart = false;

    [SerializeField] private GameObject startStuff;

    [Header("Lightning Stuff")]
    [SerializeField] private float startDelay = 30f;
    [SerializeField] private float lightningDelay = 20f;
    [SerializeField] private float rumbleTime = 5f;
    [SerializeField] private float lightningSpawnTime = 4f;

    [SerializeField] private RawImage deathOverlay;

    private float topHeight = 100f;
    private int groundLayerMask;
    private int ceilingLayerMask;
    private int triggerLayerMask;

    private Vector3 lastCheckpoint;

    public DialogueManager dialogueManager;
    
    void Awake()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
        ceilingLayerMask = LayerMask.GetMask("Ceiling");
        triggerLayerMask = LayerMask.GetMask("Lightning Triggers");
        source = GetComponent<AudioSource>();
        lastCheckpoint = playerController.transform.position;

        Color temp = deathOverlay.color;
        temp.a = 0;
        deathOverlay.color = temp;
    }

    public void StartGame()
    {
        Color temp = deathOverlay.color;
        temp.a = 1;
        deathOverlay.color = temp;

        Time.timeScale = 1;
        IsGameActive = true;
        Cursor.lockState = CursorLockMode.Locked;

        startStuff.SetActive(false);
        StartCoroutine(FadeIn(false));

        if(ActivateLightningOnStart)
            InvokeRepeating("Lightning", startDelay, lightningDelay + lightningSpawnTime);
    }
    
    public IEnumerator DeathAnim()
    {
        while(deathOverlay.color.a < 1) 
        {
            Color temp = deathOverlay.color;
            temp.a += 0.1f;
            deathOverlay.color = temp;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(2);
        Player.transform.position = GetLastCheckpoint();
        
        StartCoroutine(FadeIn(true));
    }

    public IEnumerator FadeIn(bool death)
    {
        while(deathOverlay.color.a > 0)
        {
            Color temp = deathOverlay.color;
            temp.a -= 0.1f;
            deathOverlay.color = temp;
            yield return new WaitForSeconds(0.1f);
        }

        if(death)
            Player.GetComponent<PlayerController>().PlayerDeath();
    }

    void Update()
    {
        // if(IsGameActive == false)
        // {
        //     CancelInvoke("Lightning");
        // }

        // if (player.transform.position.y < -50)
        // {
        //     GameOver();
        // }
        if(Input.GetKeyDown("f"))
        {
            dialogueManager.DisplayNextSentence();
        }
    }

    public void SetCheckPoint(Vector3 checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    public Vector3 GetLastCheckpoint()
    {
        return lastCheckpoint;
    }

    public void EnableLightning()
    {
        InvokeRepeating("Lightning", startDelay, lightningDelay + lightningSpawnTime);
    }

    public void DisableLightning()
    {
        CancelInvoke("Lightning");
    }

    public void SummonOneLightning(Vector3 pos)
    {
        Vector3 currentPlayerPos = new Vector3(pos.x, topHeight, pos.z);    
        RaycastHit hit;

        if(Physics.Raycast(currentPlayerPos, Vector3.down, out hit, Mathf.Infinity, groundLayerMask))
        {
            Vector3 lightningPos = new Vector3(currentPlayerPos.x, hit.point.y, currentPlayerPos.z);
            SummonLightning(lightningPos);
        } 
    }

    private void Lightning()
    {
        source.clip = thunderRumble;
        source.Play();
        StartCoroutine(StartThunder());
    }

    IEnumerator StartThunder() 
    {
        yield return new WaitForSeconds(rumbleTime);

        Vector3 currentPlayerPos = new Vector3(Player.transform.position.x, topHeight, Player.transform.position.z);    
        RaycastHit hit;

        if(Physics.Raycast(currentPlayerPos, Vector3.down, out hit, Mathf.Infinity, groundLayerMask))
        {
            if(!Physics.Raycast(currentPlayerPos, Vector3.down, Mathf.Infinity, ceilingLayerMask))
            {
                Vector3 lightningPos = new Vector3(currentPlayerPos.x, hit.point.y, currentPlayerPos.z);
                StartCoroutine(SpawnLightning(lightningPos));
            }
        } 
    }

    IEnumerator SpawnLightning(Vector3 pos) 
    {
        source.Stop();
        source.pitch = 2;
        source.Play();

        yield return new WaitForSeconds(lightningSpawnTime);
        source.Stop();
        source.pitch = 1;
        SummonLightning(pos);
    }

    private void SummonLightning(Vector3 pos)
    {
        source.clip = thunderStrike;
        source.Play();
        Instantiate(LightningObject, pos, LightningObject.transform.rotation);
        RaycastHit hit;
        Vector3 raycastPos = new Vector3(pos.x, topHeight, pos.z);

        if(Physics.Raycast(raycastPos, Vector3.down, out hit, Mathf.Infinity, triggerLayerMask))
        {
            if(hit.collider.isTrigger)
            {
                LightningLogic logic = hit.collider.gameObject.GetComponent<LightningLogic>();
                if(logic == null)
                    return;
                
                logic.LightningCharge();
            }
        }
    }

    /*void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            firstPersonCanvas.enabled = false;
            player.SetActive(false);
            firstPersonCanvas.enabled = false;
            gameSettings.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            firstPersonCanvas.enabled = true;
            player.SetActive(true);
            firstPersonCanvas.enabled = true;
            gameSettings.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }*/
    /*public void WinGame()
    {
        winScreen.gameObject.SetActive(true);
        playScreen.SetActive(false);
        player.SetActive(false);
        firstPersonCanvas.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        isGameActive = false;
        Time.timeScale = 0;
    }*/
    /*public void StartGame()
    {
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        gameSettings.gameObject.SetActive(false);
        player.SetActive(true);
        firstPersonCanvas.enabled = true;
        Time.timeScale = 1;
        playScreen.SetActive(true);
    }*/
    /*public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Restart Game");
    }*/
    /*public void GameOver()
    {
        isGameActive = false;
        playScreen.SetActive(false);
        player.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        Debug.Log("Game Over Screen");
        firstPersonCanvas.enabled = false;
        gameOverScreen.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }*/

    public void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("Game Over");
    }
}