using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager: MonoBehaviour{
	public enum MissionEvent {
		WHEEL_FILL,
		TARGET_FILL,
		RAMP_TAKEN,
		BALL_LOCKED,
		TIMER_DONE,
	}

	public enum MissionState {
		SPIN_WHEEL,
		TAKE_RAMP,
		HIT_TARGETS,
		LOCK_BALL,
		MULTIBALL,
	}

	private MissionState _currentState;
	public int MissionsRequired;
	private int _missionCount;
	private ScoreManager _scoreManager = ScoreManager.GetInstance();
	
	void Start() {
		_currentState = MissionState.SPIN_WHEEL;
	}

	void SendTimerDone() {
		Process(MissionEvent.TIMER_DONE);
	}

	public void Process(MissionEvent ev) {
		switch(_currentState) {
			case MissionState.SPIN_WHEEL:
				if (ev == MissionEvent.WHEEL_FILL) {
					if (Random.value < 0.5) {
						_currentState = MissionState.TAKE_RAMP;
					} else {
						_currentState = MissionState.HIT_TARGETS;
					}
					_scoreManager.AddScore(ScoreManager.MISSION_SCORE);
				}
				break;
			case MissionState.TAKE_RAMP:
				if (ev == MissionEvent.RAMP_TAKEN) {
					_currentState = MissionState.LOCK_BALL;
					_scoreManager.AddScore(ScoreManager.MISSION_SCORE);
				}
				break;
			case MissionState.HIT_TARGETS:
				if (ev == MissionEvent.TARGET_FILL) {
					_currentState = MissionState.LOCK_BALL;
					_scoreManager.AddScore(ScoreManager.MISSION_SCORE);
				}
				break;
			case MissionState.LOCK_BALL:
				if (ev == MissionEvent.BALL_LOCKED) {
					_missionCount++;
					if (_missionCount == MissionsRequired) {
						_currentState = MissionState.MULTIBALL;
						Invoke("SendTimerDone", 60f);
					} else {
						_currentState = MissionState.SPIN_WHEEL;
					}
					_scoreManager.AddScore(ScoreManager.MISSION_SCORE);
				}
				break;
			case MissionState.MULTIBALL:
				if (ev == MissionEvent.TIMER_DONE) {
					_missionCount = 0;
					_currentState = MissionState.SPIN_WHEEL;
				}
				break;
		}
	}

	public int GetCompletedMissions() {
		return _missionCount;
	}

	public MissionState GetCurrentState() {
		return _currentState;
	}

	public string GetMissionText() {
		switch (_currentState) {
			case MissionState.SPIN_WHEEL:
				return "Spin the wheel";
			case MissionState.TAKE_RAMP:
				return "Take the ramp";
			case MissionState.HIT_TARGETS:
				return "Hit the targets";
			case MissionState.LOCK_BALL:
				return "Lock the ball";
			case MissionState.MULTIBALL:
				return "MUTLIBALL!!!";
			default:
				return "Error";
		}
	}
}