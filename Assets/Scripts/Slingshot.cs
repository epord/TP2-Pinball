using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {
	public float Impulse;
	public Vector3 direction;
	private ScoreManager scoreManager;
	// Use this for initialization
	void Start () {
		scoreManager = ScoreManager.GetInstance();
	}
	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball") {
			var ball = collider.GetComponent<Rigidbody>();
			ball.AddForce(direction.normalized * Impulse , ForceMode.Impulse);
			scoreManager.AddScore(ScoreManager.SLINGSHOT_SCORE);
		}
	}
}
