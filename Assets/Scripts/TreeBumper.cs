using UnityEngine;

public class TreeBumper : MonoBehaviour
{
	public float Impulse;
    private SoundsManager soundsManager;
    public Material defaultMaterial;
    public Material onHitMaterial;
    private Renderer m_renderer;
    private float scale = 0.1F;
    private ScoreManager _scoreManager = ScoreManager.GetInstance();
    void Start ()
    {
        m_renderer = transform.parent.gameObject.GetComponentInChildren<Renderer>();
            // Get the one from the other child of the parent GetComponent<Renderer>();
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
    }
	

	void OnCollisionEnter(Collision collision)
    {
		if (collision.collider.tag == "Ball") {
			var ball = collision.collider.GetComponent<Rigidbody>();
			ball.AddForce(collision.contacts[0].normal * Impulse, ForceMode.Impulse);
            soundsManager.PlayBumper2();
            AnimateBumperOnCollision();

            _scoreManager.AddScore(ScoreManager.TARGET_SCORE);
        }
	}

    private void AnimateBumperOnCollision()
    {
        ShortBumper();
        Invoke("GrowBumper", 0.1F);
    }

    private void GrowBumper()
    {
        transform.parent.localScale += scale * transform.parent.localScale;
        m_renderer.material = defaultMaterial;
    }

    private void ShortBumper()
    {
        m_renderer.material = onHitMaterial;
        transform.parent.localScale -= scale * transform.parent.localScale;
    }
}
