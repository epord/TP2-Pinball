using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	public float Impulse;
	public Vector3 ForceDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.name == "ball") {
			Vector3 pos = transform.localPosition;
			pos.x = 0;
			transform.localPosition = pos;
			var rigidBodyBall = collider.GetComponent<Rigidbody>();
			rigidBodyBall.AddForce(ForceDirection.normalized * Impulse, ForceMode.Impulse);
		}
	}
}
