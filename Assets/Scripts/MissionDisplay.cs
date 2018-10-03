using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionDisplay : MonoBehaviour {
	private MissionManager _missionManager;
	private TextMeshProUGUI _missionText;
	private MissionManager.MissionState _oldState;

	// Use this for initialization
	void Start () {
		_missionManager = GameObject.Find("MissionManager").GetComponent<MissionManager>();
		_missionText = GetComponent<TextMeshProUGUI>();
		_oldState = _missionManager.GetCurrentState();
		_missionText.SetText(_missionManager.GetMissionText());
	}
	
	// Update is called once per frame
	void Update () {
		if (_oldState != _missionManager.GetCurrentState()) {
			_oldState = _missionManager.GetCurrentState();
			_missionText.SetText(_missionManager.GetMissionText());
		}
	}
}
