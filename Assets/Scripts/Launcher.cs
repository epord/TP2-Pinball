using UnityEngine;

public class Launcher : MonoBehaviour
{
    private float launchSpeed = -1000.0f;
    private Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate ()
    {
		if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(0, 0, launchSpeed, ForceMode.Impulse);
        }
	}
}
