using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeping : MonoBehaviour
{
    public Text scoreText;

    private OrbInfo oI;
    private int score = 100;

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
        oI = col.gameObject.GetComponent<OrbInfo>();
        score += oI.orbValue;
        scoreText.text = "Score: " + score;
        Debug.Log(score);
    }
}
