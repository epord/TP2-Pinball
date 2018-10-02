using UnityEngine;

public class MLight : MonoBehaviour
{

    public bool enable;

	void Start ()
    {
        enable = false;
	}

    private void Update()
    {
        gameObject.GetComponent<Renderer>().enabled = enable; 
    }

    public void SwitchOn()
    {
        enable = true;
    }

    public void SwitchOff()
    {
        enable = false;
    }
}
