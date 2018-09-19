using UnityEngine;

public class Flippers : MonoBehaviour
{
    private HingeJoint m_hingeJoint;
    public float ActivePosition;
    public float RestPosition;
    public string flipperInputKey;
    public float angularVelocity;

	void Start ()
    {
        m_hingeJoint = GetComponent<HingeJoint>();
    }

	void Update ()
    {
		if (Input.GetAxis(flipperInputKey) == 1)
        {
            Debug.Log("ASDASD");
            var hinge = m_hingeJoint.spring;
            hinge.targetPosition = ActivePosition;
            m_hingeJoint.spring = hinge;
        }
        else
        {
            var hinge = m_hingeJoint.spring;
            hinge.targetPosition = RestPosition;
            m_hingeJoint.spring = hinge;

        }
	}
}
