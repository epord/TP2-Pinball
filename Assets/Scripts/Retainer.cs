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
	private Queue<Rigidbody> _lockedBalls;
	private BallManager _ballManager;
	void Start()
	{
		soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
		_missionManager = GameObject.Find("MissionManager").GetComponent<MissionManager>();
		_lockedBalls = new Queue<Rigidbody>();
		_ballManager = FindObjectOfType<BallManager>();
	}

	void NewBall() {
		// TODO: Launch a new ball.
		var newBall = _ballManager.AquireBall();
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
				_lockedBalls.Enqueue(retainedBall);

                if (_missionManager.GetCurrentState() == MissionManager.MissionState.MULTIBALL)
                {
                    Invoke("ReleaseRetainedBall", 1f);
                    Invoke("ReleaseRetainedBall", 6f);
                    Invoke("ReleaseRetainedBall", 11f);
                } else
                {
                    Invoke("NewBall", 1f);
                }
			} else {
                Invoke("ReleaseBall", 1f);
            }
		}
	}

    void ReleaseRetainedBall()
    {
        var ball = _lockedBalls.Dequeue();
        ball.isKinematic = false;
        ball.AddForce(ForceDirection.normalized * Impulse, ForceMode.VelocityChange);
    }

}
