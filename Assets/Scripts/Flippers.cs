using UnityEngine;

public class Flippers : MonoBehaviour
{
    private HingeJoint m_hingeJoint;
    private SoundsManager soundsManager;
    private bool posUp;
    public float ActivePosition;
    public float RestPosition;
    public string flipperInputKey;
    public float angularVelocity;

	void Start ()
    {
        posUp = false;
        m_hingeJoint = GetComponent<HingeJoint>();
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
    }

	void Update ()
    {
		if (Input.GetAxis(flipperInputKey) == 1)
        {
            Debug.Log("ASDASD");
            var hinge = m_hingeJoint.spring;
            hinge.targetPosition = ActivePosition;
            m_hingeJoint.spring = hinge;
            if (!posUp)
            {
                soundsManager.PlayFlipperUp();
            }
            posUp = true;
        }
        else
        {
            var hinge = m_hingeJoint.spring;
            hinge.targetPosition = RestPosition;
            m_hingeJoint.spring = hinge;
            if (posUp)
            {
                soundsManager.PlayFlipperDown();
            }
            posUp = false;
        }
	}
}
