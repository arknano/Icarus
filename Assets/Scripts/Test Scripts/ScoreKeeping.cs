using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeping : MonoBehaviour
{
    public int bronzeOrbValue = 1;
    public int silverOrbValue = 5;
    public int goldOrbValue = 10;
    public Text scoreText;

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
            case "Bronze Orb":
                score += bronzeOrbValue;
                break;
            case "Silver Orb":
                score += silverOrbValue;
                break;
            case "Gold Orb":
                score += goldOrbValue;
                break;
        }
        scoreText.text = "Score: " + score;
    }
}
