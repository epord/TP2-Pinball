using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {
	private TextMeshProUGUI _scoreText;
	private ScoreManager _scoreManager = ScoreManager.GetInstance();
	private long _oldScore;

	// Use this for initialization
	void Start () {
		_scoreText = GetComponent<TextMeshProUGUI>();
		_oldScore = _scoreManager.GetScore();
		_scoreText.SetText(_oldScore.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		if (_scoreManager.GetScore() != _oldScore) {
			_oldScore = _scoreManager.GetScore();
			_scoreText.SetText(_oldScore.ToString());
		}
	}
}
