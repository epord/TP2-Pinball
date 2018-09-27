using System.Collections.Generic;
using UnityEngine;

public class Retainer : MonoBehaviour
{
	public Vector3 ForceDirection;
	public float Impulse;
	private Rigidbody retainedBall;
	private ScoreManager _scoreManager = ScoreManager.GetInstance();
    private SoundsManager soundsManager;
	private MissionManager _missionManager;
	private List<Rigidbody> _lockedBalls;
	public GameObject BallPrefab;
	void Start()
	{
		soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
		_missionManager = GameObject.Find("MissionManager").GetComponent<MissionManager>();
		_lockedBalls = new List<Rigidbody>();
	}

	void NewBall() {
		// TODO: Launch a new ball.

		var newBall = Instantiate(BallPrefab);
		var oldBall = retainedBall.GetComponent<Ball>();
	}

	void ReleaseBall()
    {
		retainedBall.isKinematic = false;
		retainedBall.AddForce(ForceDirection.normalized * Impulse, ForceMode.VelocityChange);
	}

	void OnTriggerEnter(Collider collider)
    {
        soundsManager.PlayAlarm1();
		if (collider.tag == "Ball") {
			retainedBall = collider.GetComponent<Rigidbody>();
			retainedBall.isKinematic = true;
			retainedBall.velocity = Vector3.zero;
			_scoreManager.AddScore(ScoreManager.RETAINER_SCORE);
			if (_missionManager.GetCurrentState() == MissionManager.MissionState.LOCK_BALL) {
				// Ball locked for multiball, launch a new ball
				_missionManager.Process(MissionManager.MissionEvent.BALL_LOCKED);
				_lockedBalls.Add(retainedBall);
				Invoke("NewBall", 1f);
			} else {
				Invoke("ReleaseBall", 1f);
			}
		}
	}
}
