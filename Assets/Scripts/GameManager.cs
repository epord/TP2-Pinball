using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int _highScore;
    private const string HIGHSCORE = "highScore";
    private ScoreManager scoreManager;

	void Start ()
    {
        _highScore = PlayerPrefs.GetInt(HIGHSCORE, _highScore);
        scoreManager = ScoreManager.GetInstance();
    }
	
	void Update ()
    {
		
	}

    private void OnDestroy()
    {
        int currentScore = (int)scoreManager.GetScore();
        if ( currentScore > _highScore)
        {
            PlayerPrefs.SetInt(HIGHSCORE, currentScore);
        }
    }
}
