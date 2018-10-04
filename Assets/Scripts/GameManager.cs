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
    private GameOverManager gameOverManager;
    private bool playedOnce = false;

	void Start ()
    {
        //ResetHighScore();
        _highScore = PlayerPrefs.GetInt(HIGHSCORE, _highScore);
        scoreManager = ScoreManager.GetInstance();
        scoreManager.ResetScore();
        soundManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
        ballManager = FindObjectOfType<BallManager>();
        gameOverManager = GetComponent<GameOverManager>();
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
        if (ballManager._ballsLeft <= 0 && !playedOnce)
        {
            playedOnce = true;
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.R)){
            scoreManager.AddScore(ScoreManager.SCORE_FOR_NEW_BALL);
        }
    }

    private void GameOver()
    {
        soundManager.PlayWablaDubDub();
        gameOverManager.isGameOver = true;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(HIGHSCORE, _highScore);
        Debug.Log(PlayerPrefs.GetInt(HIGHSCORE));
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
