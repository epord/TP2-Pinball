using UnityEngine;

public class Retainer : MonoBehaviour
{
	public Vector3 ForceDirection;
	public float Impulse;
	private Rigidbody retainedBall;
	private ScoreManager _scoreManager = ScoreManager.GetInstance();
    private SoundsManager soundsManager;

	void ReleaseBall()
    {
		retainedBall.isKinematic = false;
		retainedBall.AddForce(ForceDirection.normalized * Impulse, ForceMode.VelocityChange);
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
	}

	void OnTriggerEnter(Collider collider)
    {
        soundsManager.PlayAlarm1();
		if (collider.name == "ball") {
			retainedBall = collider.GetComponent<Rigidbody>();
			retainedBall.isKinematic = true;
			retainedBall.velocity = Vector3.zero;
			_scoreManager.AddScore(ScoreManager.RETAINER_SCORE);
			Invoke("ReleaseBall", 1f);
		}
	}
}
