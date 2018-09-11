using UnityEngine;

public class Flippers : MonoBehaviour
{
    private HingeJoint m_hingeJoint;
    private JointSpring m_jointSpring;
    private float springForce = 750.0f;
    private float springDamper = 1.0f;
    private float restPosition = 0.0f;
    public float activePosition;
    public string flipperInputKey;

	void Start ()
    {
        m_hingeJoint = GetComponent<HingeJoint>();
        m_jointSpring = new JointSpring();
        m_jointSpring.spring = springForce;
        m_jointSpring.damper = springDamper;
    }
	
	void Update ()
    {
		if (Input.GetAxis(flipperInputKey) == 1)
        {
            m_jointSpring.targetPosition = activePosition;
        }
        else
        {
            m_jointSpring.targetPosition = restPosition;
        }
        m_hingeJoint.spring = m_jointSpring;
	}
}
