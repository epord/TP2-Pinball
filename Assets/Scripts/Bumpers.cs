using UnityEngine;

public class Bumpers : MonoBehaviour {

    public float bumpForce;
    public Material defaultMaterial;
    public Material onHitMaterial;
    private Renderer m_renderer;
    private float scale = 0.1F;
    private SoundsManager soundsManager;

    private void Start()
    {
        m_renderer = GetComponent<Renderer>();
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            soundsManager.PlayBumper1();
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
        transform.localScale += new Vector3(scale, scale, scale);
        m_renderer.material = defaultMaterial;
    }

    private void ShortBumper()
    {
        m_renderer.material = onHitMaterial;
        transform.localScale -= new Vector3(scale, scale, scale);
    }
}
