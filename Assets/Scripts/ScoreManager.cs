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
	public static long SCORE_FOR_NEW_BALL = 5000;

	private static ScoreManager instance;

	private long _score;
	private long _newBallAcum;
	private bool _newBall;
	private ScoreManager(){}

	public static ScoreManager GetInstance()
	{
		if (instance == null){
			instance = new ScoreManager();
		}
		return instance;
	}
	
	public void AddScore(long score) {
		_score += score;
		_newBallAcum += score;
		if (_newBallAcum >= SCORE_FOR_NEW_BALL) {
			_newBall = true;
			_newBallAcum -= SCORE_FOR_NEW_BALL;
		}
	}

	public bool AddBall() {
		if (_newBall) {
			_newBall = false;
			return true;
		}
		return false;
	}

	public long GetScore() {
		return _score;
	}
}
