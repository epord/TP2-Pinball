using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallsLeftDisplay : MonoBehaviour {
	BallManager _ballManager;
    private SoundsManager soundsManager;
	TextMeshProUGUI _text;
	int _oldCount;
	// Use this for initialization
	void Start () {
		_ballManager = FindObjectOfType<BallManager>();
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
		_text = GetComponent<TextMeshProUGUI>();
		_oldCount = _ballManager.BallsLeftCount() - 1;
		_text.text = _oldCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (_oldCount != _ballManager.BallsLeftCount() - 1 && _ballManager.BallsLeftCount() != 0)
        {
            if (_ballManager.BallsLeftCount() < 3)
            {
                soundsManager.PlayBallLoss();
            }
			_oldCount = _ballManager.BallsLeftCount() - 1;
			_text.text = _oldCount.ToString();
		}
	}
}
