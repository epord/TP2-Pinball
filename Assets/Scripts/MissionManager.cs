using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager: MonoBehaviour{
	public enum MissionEvent {
		BALL_LOST,
		LAUNCHED,
		WHEEL_FILL,
		TARGET_FILL,
		RAMP_TAKEN,
		BALL_LOCKED
	}

	public enum MissionState {
		LAUNCHING,
		SPIN_WHEEL,
		TAKE_RAMP,
		HIT_TARGETS,
		LOCK_BALL,
		MULTIBALL,
	}

	private MissionState _currentState;
	private BallManager _ballManager;
	public int MissionsRequired;
	private int _missionCount;
	private ScoreManager _scoreManager = ScoreManager.GetInstance();
	private int _multiballCount;
	
	void Start() {
		_currentState = MissionState.LAUNCHING;
		_ballManager = FindObjectOfType<BallManager>();
	}

	public void Process(MissionEvent ev) {

		switch(_currentState) {
			case MissionState.LAUNCHING:
				if (ev == MissionEvent.LAUNCHED) {
					_currentState = MissionState.SPIN_WHEEL;
				}
				break;
			case MissionState.SPIN_WHEEL:
				if (ev == MissionEvent.WHEEL_FILL) {
					if (Random.value < 0.5) {
						_currentState = MissionState.TAKE_RAMP;
					} else {
						_currentState = MissionState.HIT_TARGETS;
					}
					_scoreManager.AddScore(ScoreManager.MISSION_SCORE);
				}
				if (ev == MissionEvent.BALL_LOST) {
					_currentState = MissionState.LAUNCHING;
					_ballManager.LoseBall();
				}
				break;
			case MissionState.TAKE_RAMP:
				if (ev == MissionEvent.RAMP_TAKEN) {
					_currentState = MissionState.LOCK_BALL;
					_scoreManager.AddScore(ScoreManager.MISSION_SCORE);
				}
				if (ev == MissionEvent.BALL_LOST) {
					_currentState = MissionState.LAUNCHING;
					_ballManager.LoseBall();
				}
				break;
			case MissionState.HIT_TARGETS:
				if (ev == MissionEvent.TARGET_FILL) {
					_currentState = MissionState.LOCK_BALL;
					_scoreManager.AddScore(ScoreManager.MISSION_SCORE);
				}
				if (ev == MissionEvent.BALL_LOST) {
					_currentState = MissionState.LAUNCHING;
					_ballManager.LoseBall();
				}
				break;
			case MissionState.LOCK_BALL:
				if (ev == MissionEvent.BALL_LOCKED) {
					_missionCount++;
					if (_missionCount == MissionsRequired) {
						_currentState = MissionState.MULTIBALL;
						_multiballCount = 3;
					} else {
						_currentState = MissionState.LAUNCHING;
					}
					_scoreManager.AddScore(ScoreManager.MISSION_SCORE);
				}
				if (ev == MissionEvent.BALL_LOST) {
					_currentState = MissionState.LAUNCHING;
					_ballManager.LoseBall();
				}
				break;
			case MissionState.MULTIBALL:
				if (ev == MissionEvent.BALL_LOST) {
					_multiballCount--;
					if (_multiballCount == 1) {
						_currentState = MissionState.SPIN_WHEEL;
					}
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
			case MissionState.LAUNCHING:
				return "Launch the ball";
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