using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retainer : MonoBehaviour {
	public Vector3 ForceDirection;
	public float Impulse;

	private Rigidbody retainedBall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ReleaseBall() {
		retainedBall.isKinematic = false;
		retainedBall.AddForce(ForceDirection.normalized * Impulse, ForceMode.VelocityChange);
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.name == "ball") {
			retainedBall = collider.GetComponent<Rigidbody>();
			retainedBall.isKinematic = true;
			retainedBall.velocity = Vector3.zero;
			Invoke("ReleaseBall", 1f);
		}
	}
}
