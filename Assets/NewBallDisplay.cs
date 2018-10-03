using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBallDisplay : MonoBehaviour {
	BallManager _ballManager;
	TextMeshProUGUI _newBallText;
	// Use this for initialization
	void Start () {
		_ballManager = FindObjectOfType<BallManager>();
		_newBallText = GetComponent<TextMeshProUGUI>();
		_newBallText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (_ballManager.NewBall()) {
			_newBallText.enabled = true;
			Invoke("HideNewBallText", 5f);
		}
	}

	void HideNewBallText() {
		_newBallText.enabled = false;
	}
}
