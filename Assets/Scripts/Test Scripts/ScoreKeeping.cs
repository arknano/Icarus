using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeping : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    private OrbInfo oI;
    private int score;
    private int oldHS;

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

        int oldHS = PlayerPrefs.GetInt("HighScore", 0);
        if(score > oldHS)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "Best: " + score;
        }
        PlayerPrefs.Save();
    }
}
