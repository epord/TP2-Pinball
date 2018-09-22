using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {
	public float RotationSpeed;
	public float RotationDamp;
	public float currSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currSpeed > 0) {
			transform.Rotate( Vector3.right * currSpeed * Time.deltaTime);
			currSpeed = currSpeed - Time.deltaTime * RotationDamp;
		}
		
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.name == "ball") {
			var ball = collider.GetComponent<Rigidbody>();
			currSpeed = ball.velocity.magnitude * RotationSpeed;
		}
	}
}
