using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static int _highScore;
    private const string HIGHSCORE = "highScore";
    private ScoreManager scoreManager;
    private SoundsManager soundManager;

	void Start ()
    {
        _highScore = PlayerPrefs.GetInt(HIGHSCORE, _highScore);
        scoreManager = ScoreManager.GetInstance();
        soundManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
        soundManager.PlayRickAndMortyTheme();
    }
	
	void Update ()
    {
        int currentScore = (int)scoreManager.GetScore();
        if (currentScore > _highScore)
        {
            _highScore = currentScore;
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(HIGHSCORE, _highScore);
    }

    public int GetHighScore()
    {
        return _highScore;
    }
}
