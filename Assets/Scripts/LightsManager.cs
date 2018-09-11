using UnityEngine;

public class LightsManager : MonoBehaviour
{
    private bool on;
    private Light light;

	void Start ()
    {
        on = false;
        light = GetComponent<Light>();
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            if (!on)
                SwitchOn();
            else
                SwitchOff();
        }
    }

    public void SwitchOn()
    {
        on = true;
        light.enabled = true;
    }

    public void SwitchOff()
    {
        on = false;
        light.enabled = false;
    }
}
