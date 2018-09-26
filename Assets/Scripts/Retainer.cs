using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retainer : MonoBehaviour {
	public Vector3 ForceDirection;
	public float Impulse;
	private Rigidbody retainedBall;
	private ScoreManager _scoreManager = ScoreManager.GetInstance();
	void ReleaseBall() {
		retainedBall.isKinematic = false;
		retainedBall.AddForce(ForceDirection.normalized * Impulse, ForceMode.VelocityChange);
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.name == "ball") {
			retainedBall = collider.GetComponent<Rigidbody>();
			retainedBall.isKinematic = true;
			retainedBall.velocity = Vector3.zero;
			_scoreManager.AddScore(ScoreManager.RETAINER_SCORE);
			Invoke("ReleaseBall", 1f);
		}
	}
}
