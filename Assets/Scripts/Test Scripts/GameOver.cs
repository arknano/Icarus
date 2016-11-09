using UnityEngine;
using InControl;
using System.Collections;

public class GameOver : MonoBehaviour
{
    private GameObject[] pausedObjects;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1f;
        pausedObjects = GameObject.FindGameObjectsWithTag("OnPause");
        //hidePaused();
	}
	
	// Update is called once per frame
	void Update ()
    {
      
    }

    public void EndGame()
    {
        Time.timeScale = 0;

    }
}
