using UnityEngine;

public class Launcher : MonoBehaviour
{
    private MissionManager _missionManager;
    public float launchSpeed;
    private BallManager _ballManager;
    public float maxLaunchSpeed;
    public float step;
    private SoundsManager soundsManager;
    private LightsManager lightsManager;
    private float _lastUpdate;
    public float LightTimeStep;
    public int NumberOfLights;

	private void Start()
	{
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
        lightsManager = GameObject.Find("LightsManager").GetComponent<LightsManager>();
        _ballManager = FindObjectOfType<BallManager>();
        _missionManager = FindObjectOfType<MissionManager>();
    }

    void OnTriggerEnter()
    {
        launchSpeed = 0;
    }

    void OnTriggerStay(Collider collider)
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            var ball = collider.gameObject;
            var rb = ball.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, launchSpeed, 0), ForceMode.Impulse);
            soundsManager.PlayLauncher();
        }

        if (Input.GetKey(KeyCode.Space) && _lastUpdate + LightTimeStep < Time.time)
        {
            _lastUpdate = Time.time;
            launchSpeed = launchSpeed + step > maxLaunchSpeed ? maxLaunchSpeed : launchSpeed + step;
            var lightStep = maxLaunchSpeed / NumberOfLights;
            var lightsOn = (int)(launchSpeed / lightStep);
            lightsManager.SwitchLauncherLights(lightsOn);
        }
	}
}
