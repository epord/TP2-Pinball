using UnityEngine;

public class TreeBumper : MonoBehaviour
{
	public float Impulse;
    private SoundsManager soundsManager;
    public Material defaultMaterial;
    public Material onHitMaterial;
    private Renderer m_renderer;
    private float scale = 0.1F;

    void Start ()
    {
        m_renderer = transform.parent.gameObject.GetComponentInChildren<Renderer>();
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
    }
	

	void OnCollisionEnter(Collision collision)
    {
		if (collision.collider.name == "ball") {
			var ball = collision.collider.GetComponent<Rigidbody>();
			ball.AddForce(collision.contacts[0].normal * Impulse, ForceMode.Impulse);
            soundsManager.PlayBumper2();
            AnimateBumperOnCollision();
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
