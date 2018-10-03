using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLight : MonoBehaviour {

    public Material LitMaterial;
    public Material UnlitMaterial;
    private Renderer m_renderer;

	// Use this for initialization
	void Start () {
        m_renderer = GetComponent<Renderer>();
        m_renderer.material = UnlitMaterial;
	}

    public void TurnOn()
    {
        m_renderer.material = LitMaterial;
    }

    public void TurnOff()
    {
        m_renderer.material = UnlitMaterial;
    }
}
