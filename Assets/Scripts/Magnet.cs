﻿using UnityEngine;

public class Magnet : MonoBehaviour
{
    // ALL CONSTANTS ARE TO BE CHANGED TO MAKE THE BEST GAMEPLAY POSSIBLE
    public bool repulse = false;
    public bool attract = false;
    public bool activated = false;
    public Material attractMaterial;
    public Material repulseMaterial;
    private Renderer m_renderer;
    private float nextActivation;
    private float nextActivationMin = 10f;
    private float nextActivationMax = 20f;
    private float m_activationTime = 5f;
    private float activationTime;
    private float m_time = 0f;
    private GameObject ball;
    public float magnetForce = 25f;

    void Start ()
    {
        nextActivation = Random.Range(nextActivationMin, nextActivationMax);
        activationTime = m_activationTime;
        m_renderer = GetComponent<Renderer>();
        m_renderer.enabled = false;
    }
	
	void Update ()
    {
		if (m_time < nextActivation && !activated)
        {
            m_time += Time.deltaTime;
        }
        else if (m_time >= nextActivation && !activated)
        {
            activated = true;
            ActivateRandomState();
            m_time = 0f;
        }

        if (activationTime > 0f &&  activated)
        {
            activationTime -= Time.deltaTime;
        }
        else if (activationTime <= 0f && activated)
        {
            activated = false;
            repulse = false;
            attract = false;
            activationTime = m_activationTime;
            m_renderer.enabled = false;
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ball")
        {
            var ball = other.GetComponent<Rigidbody>();
            if (repulse)
            {
                Repulse(ball);
            }
            else if (attract)
            {
                Attract(ball);
            }
        }
    }

    private void Repulse(Rigidbody ball)
    {
        Vector3 dir = ball.transform.position -transform.position;
        ball.AddForce(dir.x * magnetForce, dir.y * magnetForce, 0, ForceMode.Force);
    }

    private void Attract(Rigidbody ball)
    {
        Vector3 dir = transform.position - ball.transform.position;
        ball.AddForce(dir.x * magnetForce, dir.y * magnetForce, 0, ForceMode.Force);
    }

    private void ActivateRandomState()
    {
        float r = Random.value;
        if (r > 0.5)
        {
            repulse = true;
            m_renderer.material = repulseMaterial;
            m_renderer.enabled = true;
        }
        else
        {
            attract = true;
            m_renderer.material = attractMaterial;
            m_renderer.enabled = true;
        }
    }
}
