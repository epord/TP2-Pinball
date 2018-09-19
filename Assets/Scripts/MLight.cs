using UnityEngine;

public class MLight : MonoBehaviour {

    public bool enable;
    //public bool randomBlinkingState;

	void Start () {
        enable = false;
        //randomBlinkingState = false;
	}

    private void Update()
    {
        gameObject.GetComponent<Light>().enabled = enable; 
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
