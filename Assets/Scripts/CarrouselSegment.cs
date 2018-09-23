using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrouselSegment : MonoBehaviour {
	public Material HitMaterial;
	// Use this for initialization
	private Renderer _renderer;
	void Start () {
		_renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.name == "ball") {
			_renderer.material = HitMaterial;
		}
	}
}
