using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int maxLives = 3;
    public string healthTag = "HealthPack";

    private HealthPackValue hPV;
    private int currentLives;

    public int CurrentLives
    {
        get { return currentLives; }
        set { currentLives = value; }
    }

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
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "HealthPack")
        {
            AddHealth(hPV.healthPackValue);
            Destroy(col.gameObject);
        }
    }

    public void AddHealth(int health)
    {
        if(!(currentLives >= maxLives))
        {
            currentLives += health;
        }
        else if(currentLives >= maxLives)
        {
            currentLives = maxLives;
        }
             
    }
}
