using UnityEngine;
using InControl;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class UIManager : MonoBehaviour
{
    InputDevice device;
    public GameObject player;
    public GameObject newCamera;

    public Sprite fullHealth, twoHealth, oneHealth, noHealth, happyFace, sadFace;
    public Image Face, Hearts;

    private GameObject[] gameOverObjects;
    private GameObject[] pausedObjects;
    private Blur blur;
    private Health health;
   
    // Use this for initialization
    void Start ()
    {
        health = player.GetComponent<Health>();
        blur = newCamera.GetComponent<Blur>();

        Time.timeScale = 1f;
        pausedObjects = GameObject.FindGameObjectsWithTag("OnPause");
        gameOverObjects = GameObject.FindGameObjectsWithTag("OnGameOver");
        HidePaused();
        HideGameOver();
        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        Debug.Log("HI");

        device = InputManager.ActiveDevice;

        if (device.MenuWasPressed || Input.GetKeyDown(KeyCode.Escape)) 
        { 
            Debug.Log("working");
            if (Time.timeScale == 1)
            { 
                ShowPaused();
            }
            else if(Time.timeScale == 0)
            {
                HidePaused();
            }
        }
        Health();
    }

    public void Reload()
    {
        blur.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowPaused()
    {
        foreach(GameObject g in pausedObjects)
        {
            g.SetActive(true);
        }
        Time.timeScale = 0;
    }

    public void HidePaused()
    {
        foreach (GameObject g in pausedObjects)
        {         
            g.SetActive(false);
        }
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        Debug.Log("Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Health()
    {
        if (health.CurrentLives == 3)
        {
            Face.sprite = happyFace;
            Hearts.sprite = fullHealth;
        }
        if (health.CurrentLives == 2)
        {
            Face.sprite = happyFace;
            Hearts.sprite = twoHealth;
        }
        if (health.CurrentLives == 1)
        {
            Face.sprite = sadFace;
            Hearts.sprite = oneHealth;
        }
        if (health.CurrentLives == 0)
        {
            Face.sprite = sadFace;
            Hearts.sprite = noHealth;

            EndGame();
        }
    }

    public void ShowGameOver()
    {
        foreach (GameObject g in gameOverObjects)
        {
            g.SetActive(true);
        }
    }

    public void HideGameOver()
    {
        foreach (GameObject g in gameOverObjects)
        {
            g.SetActive(false);
        }
    }

    public void EndGame()
    {
        blur.enabled = true;
        ShowGameOver();
        ShowPaused();
    }
}