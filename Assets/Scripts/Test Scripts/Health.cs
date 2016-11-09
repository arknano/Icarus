using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int maxLives = 3;
    public string healthTag = "HealthPack";

    private HealthPackValue hPV;
    private int currentLives;

	// Use this for initialization
	void Start ()
    {
        currentLives = maxLives;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void TakeDamage(int damage)
    {
        currentLives -= damage;
        if(currentLives <= 0)
        {
            //End
        }
    }
}
