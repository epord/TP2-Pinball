using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static int _highScore;
    private const string HIGHSCORE = "highScore";
    private ScoreManager scoreManager;
    private SoundsManager soundManager;
    public bool newHighScore = false;
    private BallManager ballManager;
    private PauseManager pauseManager;

	void Start ()
    {
        //ResetHighScore();
        _highScore = PlayerPrefs.GetInt(HIGHSCORE, _highScore);
        scoreManager = ScoreManager.GetInstance();
        soundManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
        ballManager = GameObject.Find("BallManager").GetComponent<BallManager>();
        pauseManager = GameObject.Find("PauseManager").GetComponent<PauseManager>();
        soundManager.PlayRickAndMortyTheme();
    }
	
	void Update ()
    {
        int currentScore = (int)scoreManager.GetScore();
        if (currentScore > _highScore)
        {
            _highScore = currentScore;
            if (!newHighScore)
            {
                newHighScore = true;
            }
        }
        if (ballManager._ballsLeft < 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        //Pausing with a different interface
        pauseManager.firstButtonText = "New Game";
        pauseManager.isGamePaused = true;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(HIGHSCORE, _highScore);
    }

    public int GetHighScore()
    {
        return _highScore;
    }

    private void ResetHighScore()
    {
        PlayerPrefs.SetInt(HIGHSCORE, 0);
    }
}
