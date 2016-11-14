using UnityEngine;
using InControl;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject player;

    public Sprite fullHealth, twoHealth, oneHealth, noHealth, happyFace, sadFace;
    public Image Face, Hearts;

    private GameObject[] pausedObjects;
    private Health health; 

    // Use this for initialization
    void Start ()
    {
        health = player.GetComponent<Health>();

        Time.timeScale = 1f;
        pausedObjects = GameObject.FindGameObjectsWithTag("OnPause");
        HidePaused();
    }

    // Update is called once per frame
    void Update ()
    {
        Debug.Log("HI");
        InputDevice device = InputManager.ActiveDevice;

        if(Input.GetKeyDown(KeyCode.Escape) || device.Action2)
        {
            Debug.Log("HI");
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                ShowPaused();
            }
            else if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
                HidePaused();
            }
        }
        Health();
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowPaused()
    {
        foreach(GameObject g in pausedObjects)
        {
            g.SetActive(true);
        }
    }

    public void HidePaused()
    {
        foreach (GameObject g in pausedObjects)
        {
            g.SetActive(false);
        }
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
        }
    }
}