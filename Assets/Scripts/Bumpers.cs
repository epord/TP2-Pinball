using UnityEngine;

public class Bumpers : MonoBehaviour {

    public Material defaultMaterial;
    public Material onHitMaterial;
    private Renderer m_renderer;
    private float scale = 0.1F;

    private void Start()
    {
        m_renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "ball")
        {
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
        transform.localScale += scale * transform.localScale;
        m_renderer.material = defaultMaterial;
    }

    private void ShortBumper()
    {
        m_renderer.material = onHitMaterial;
        transform.localScale -= scale * transform.localScale;
    }
}
