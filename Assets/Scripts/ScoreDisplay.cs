using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {
	private TextMeshProUGUI _scoreText;
	private ScoreManager _scoreManager;

	// Use this for initialization
	void Start () {
		_scoreText = GetComponent<TextMeshProUGUI>();
		_scoreManager = ScoreManager.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
		_scoreText.SetText(_scoreManager.GetScore().ToString());
	}
}
