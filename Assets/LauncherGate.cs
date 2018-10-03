using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherGate : MonoBehaviour {
	private MissionManager _missionManager;
	private BoxCollider _boxCollider;
	private bool _launching;

	// Use this for initialization
	void Start () {
		_boxCollider = GetComponent<BoxCollider>();
		_missionManager = FindObjectOfType<MissionManager>();
		_boxCollider.isTrigger = true;
	}

	void Update() {
		if (!_launching && _missionManager.GetCurrentState() == MissionManager.MissionState.LAUNCHING) {
			_launching = true;
			_boxCollider.isTrigger = true;
		}
	}
	
	void OnTriggerExit() {
		if (_missionManager.GetCurrentState() == MissionManager.MissionState.LAUNCHING) {
			_missionManager.Process(MissionManager.MissionEvent.LAUNCHED);
			_boxCollider.isTrigger = false;
			_launching = false;
		}
	}
}
