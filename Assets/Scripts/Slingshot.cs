using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {
	public float Impulse;
	public Vector3 direction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.name == "ball") {
			var ball = collider.GetComponent<Rigidbody>();
			ball.AddForce(direction.normalized * Impulse , ForceMode.Impulse);
		}
	}
}
