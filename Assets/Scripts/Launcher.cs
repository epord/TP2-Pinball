using UnityEngine;

public class Launcher : MonoBehaviour
{
    public float launchSpeed = 0.0f;
    private BallManager _ballManager;
    private Rigidbody rb;
    public float maxLaunchSpeed = 100f;
    public float step = 50f;
    private SoundsManager soundsManager;
    private LightsManager lightsManager;
    private float _lastUpdate;

	private void Start()
	{
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
        lightsManager = GameObject.Find("LightsManager").GetComponent<LightsManager>();
        _ballManager = FindObjectOfType<BallManager>();
    }

    void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            var ball = _ballManager.AquireBall();
            var rb = ball.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, launchSpeed, 0);
            launchSpeed = 0.0f;
            //lightsManager.SwitchOff(lightsManager.launcherLights);
            soundsManager.PlayLauncher();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _lastUpdate = Time.time;
            launchSpeed = launchSpeed + step > maxLaunchSpeed ? maxLaunchSpeed : launchSpeed + step;
            var lightStep = maxLaunchSpeed / 8;
            var lightsOn = (int)(launchSpeed / lightStep);
            Debug.Log(lightsOn);
            lightsManager.SwitchLauncherLights(lightsOn);
        }
	}
}
