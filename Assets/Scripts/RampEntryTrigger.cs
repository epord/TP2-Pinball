using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampEntryTrigger : MonoBehaviour
{
    private MissionManager _missionManager;
    private ScoreManager _scoreManager = ScoreManager.GetInstance();

    public void Start() {
        _missionManager = GameObject.Find("MissionManager").GetComponent<MissionManager>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ball")
        {
            var ball = collider.GetComponent<Rigidbody>();
            Debug.Log("enters");
            Debug.Log(ball.position);
            Debug.Log(ball.velocity);

           var newPosition = new Vector3(0.2113f, 0.4152f, 0.0021f);
           ball.position = newPosition;
           ball.velocity = new Vector3(0.0f, 2.0f, 0.0f);

           _scoreManager.AddScore(ScoreManager.RAMP_SCORE);
           _missionManager.Process(MissionManager.MissionEvent.RAMP_TAKEN);
        }
    }
}
