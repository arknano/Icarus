using UnityEngine;
using System.Collections;

public class ScoreKeeping : MonoBehaviour
{
    public int bronzeOrbValue = 1;
    public int silverOrbValue = 5;
    public int goldOrbValue = 10;

    private int score;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void AddScore(Collider col)
    {
        switch(col.gameObject.name)
        {
            case "bronzeOrb":
                score += bronzeOrbValue;
                break;
            case "silverOrb":
                score += silverOrbValue;
                break;
            case "goldOrb":
                score += goldOrbValue;
                break;
        }

    }
}
