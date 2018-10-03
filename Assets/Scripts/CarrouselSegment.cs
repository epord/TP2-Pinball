using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrouselSegment : MonoBehaviour {
	public Material HitMaterial;
	// Use this for initialization
	private Renderer _renderer;
	private ScoreManager _scoreManager = ScoreManager.GetInstance();
	public bool _hit;
	public Material _unLitMaterial;
	void Start () {
		_renderer = GetComponent<Renderer>();
		_unLitMaterial = _renderer.material;
	}
	
	public bool IsLit() {
		return _hit;
	}

	public void Reset() {
		_hit = false;
		_renderer.material = _unLitMaterial;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Ball" && !_hit) {
			_renderer.material = HitMaterial;
			_hit = true;
			_scoreManager.AddScore(ScoreManager.CARROUSEL_SEGMENT_SCORE);
		}
	}
}
