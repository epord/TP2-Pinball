using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampEntryTrigger : MonoBehaviour
{
    private MissionManager _missionManager;
    private ScoreManager _scoreManager = ScoreManager.GetInstance();
    private LightsManager lightsManager;
    private SoundsManager soundsManager;
    private List<GameObject> rampLights1;
    private List<GameObject> rampLights2;

    public void Start() {
        _missionManager = GameObject.Find("MissionManager").GetComponent<MissionManager>();
        lightsManager = GameObject.Find("LightsManager").GetComponent<LightsManager>();
        rampLights1 = lightsManager.rampLights1;
        rampLights2 = lightsManager.rampLights2;
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            lightsManager.BlinkRamp(0.2f, rampLights1);
            lightsManager.BlinkRamp(0.2f, rampLights2);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ball")
        {
            var ball = collider.GetComponent<Rigidbody>();
            Debug.Log("enters");
            Debug.Log(ball.position);
            Debug.Log(ball.velocity);

            var newPosition = new Vector3(0.2224f, 0.4206f, 0.007f);
           ball.position = newPosition;
           ball.velocity = new Vector3(0.0f, 2.0f, 0.0f);

           _scoreManager.AddScore(ScoreManager.RAMP_SCORE);
           _missionManager.Process(MissionManager.MissionEvent.RAMP_TAKEN);
            lightsManager.BlinkRamp(0.2f, rampLights1);
            lightsManager.BlinkRamp(0.2f, rampLights2);
            soundsManager.PlayAlarm2();
        }
    }
}
