using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This component manages scores, and sets and resets game props depending on the mission 
// status.
public class ScoreManager {
	public static long SLINGSHOT_SCORE = 10;
	public static long CARROUSEL_SEGMENT_SCORE = 10;
	public static long CARROUSEL_FULL_SCORE = 100;
	public static long TARGET_SCORE = 10;
	public static long TARGET_BUNDLE_SCORE = 100;
	public static long RETAINER_SCORE = 100;
	public static long RAMP_SCORE = 100;
	public static long MISSION_SCORE = 1000;
	public static long BALL_LOCKED = 1000;

	private static ScoreManager instance;

	private long _score;
	private ScoreManager(){}

	public static ScoreManager GetInstance()
	{
		if (instance == null){
			instance = new ScoreManager();
		}
        //_highScore = PlayerPrefs.GetInt("highScore", _highScore);
        //Debug.Log(_highScore);
		return instance;
	}
	
	public void AddScore(long score) {
		_score += score;
	}

	public long GetScore() {
        //Debug.Log(_score);
		return _score;
	}
}
