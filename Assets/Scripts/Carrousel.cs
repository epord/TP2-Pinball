using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrousel : MonoBehaviour {
	private CarrouselSegment[] _segments;
	private MissionManager _missionManager;
	private ScoreManager _scoreManager = ScoreManager.GetInstance();
	// Use this for initialization
	void Start () {
		_segments = GetComponentsInChildren<CarrouselSegment>();
		_missionManager = GameObject.Find("MissionManager").GetComponent<MissionManager>();
	}
	
	// Update is called once per frame
	void Update () {
		bool allAreLit = true;
		foreach(var segment in _segments) {
			if (!segment.IsLit()) {
				allAreLit = false;
				break;
			}
		}
		if (allAreLit) {
			_scoreManager.AddScore(ScoreManager.CARROUSEL_FULL_SCORE);
			_missionManager.Process(MissionManager.MissionEvent.WHEEL_FILL);
			foreach(var segment in _segments) {
				segment.Reset();
			} 
 		}
	}
}
