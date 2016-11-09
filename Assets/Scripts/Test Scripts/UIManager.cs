using UnityEngine;
using InControl;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameObject[] pausedObjects;

    // Use this for initialization
    void Start ()
    {
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
}