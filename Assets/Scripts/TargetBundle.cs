using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBundle : MonoBehaviour {
	private Target[] _targets;
	private ScoreManager _scoreManager = ScoreManager.GetInstance();
	// Use this for initialization
	void Start () {
		_targets = GetComponentsInChildren<Target>(false);
	}
	
	// Update is called once per frame
	void Update () {
		bool allTargetsDown = true;

		foreach (var target in _targets) {
			if (!target.IsDown()) {
				allTargetsDown = false;
			}
		}

		if (allTargetsDown) {
			_scoreManager.AddScore(ScoreManager.TARGET_BUNDLE_SCORE);
			foreach (var target in _targets) {
				target.Reset();
			}
		}
	}
}
