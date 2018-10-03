using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrap : MonoBehaviour {
	private MissionManager _missionManager;
	private BallManager _ballManager;


	// Use this for initialization
	void Start () {
		_missionManager = FindObjectOfType<MissionManager>();
		_ballManager = FindObjectOfType<BallManager>();
	}
	
	void OnTriggerEnter(Collider collider) 
	{
		if (collider.tag == "Ball") {
			var ball = collider.GetComponent<Ball>();
			_ballManager.ReleaseBall(ball);
			_missionManager.Process(MissionManager.MissionEvent.BALL_LOST);
		}
	}
}
