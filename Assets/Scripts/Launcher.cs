using UnityEngine;

public class Launcher : MonoBehaviour
{
    public float launchSpeed = 0.0f;
    public GameObject lauchedObject;
    private Rigidbody rb;
    public float maxLaunchSpeed = 0.2f;
    public float step = 0.001f;
    private SoundsManager soundsManager;

	private void Start()
	{
        rb = lauchedObject.GetComponent<Rigidbody>();
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
    }

	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(0, launchSpeed, 0, ForceMode.Impulse);
            launchSpeed = 0.0f;
            soundsManager.PlayLauncher();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            launchSpeed = launchSpeed + step > maxLaunchSpeed ? maxLaunchSpeed : launchSpeed + step;
        }
	}
}
