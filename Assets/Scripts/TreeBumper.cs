using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBumper : MonoBehaviour {
	public float Impulse;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.name == "ball") {
			var ball = collision.collider.GetComponent<Rigidbody>();
			ball.AddForce(collision.contacts[0].normal * Impulse, ForceMode.Impulse);
		}
	}
}
