using UnityEngine;

public class Door : MonoBehaviour
{
    private Vector3 openPos;
    private Vector3 closePos;
    private float speed = 10f;
    private float step;
    public Vector3 pos;
    public bool opened;

	void Start ()
    {
        opened = true;
        openPos = transform.localPosition;
        closePos = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.5f, transform.localPosition.z + 0);
	}
	
	void Update ()
    {
        pos = transform.localPosition;
	}

    public void Close()
    {
        step = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, closePos, step);
        opened = false;
    }

    public void Open()
    {
        step = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, openPos, step);
        opened = true;
    }
}
