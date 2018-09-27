using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	public float Impulse;
	public Vector3 ForceDirection;
	private ScoreManager _scoreManager = ScoreManager.GetInstance();
	private float _initialPosX;
	private bool _isDown;
	void Start() {
		_initialPosX = transform.localPosition.x;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball") {
			Vector3 pos = transform.localPosition;
			pos.x = 0;
			_isDown = true;
			transform.localPosition = pos;
			var rigidBodyBall = collider.GetComponent<Rigidbody>();
			rigidBodyBall.AddForce(ForceDirection.normalized * Impulse, ForceMode.Impulse);
			_scoreManager.AddScore(ScoreManager.TARGET_SCORE);
		}
	}

	public bool IsDown() {
		return _isDown;
	}

	public void Reset() {
		Vector3 pos = transform.localPosition;
		pos.x = _initialPosX;
		transform.localPosition = pos;
		_isDown = false;
	}
}
