using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public string BallResetKey = "ResetBallKey";
    public Vector3 resPos;
    public Vector3 HidePosition;
    private Rigidbody _rigidBody;

    void Start ()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        // Reset ball position when it falls from the map
        // if (transform.position.z < -3.5)
        // {
        //     transform.position = resPos;
        // }

        // Close the door when lauching is down, open it for new launch
        // USE POSITION, 3.5 IS JUST AN APPORXIMATION FOR THE TEST

        if (!_rigidBody.isKinematic && Input.GetButton(BallResetKey)) {
            ResetPosition();
        }
    }

    public void ResetPosition() {
        transform.position = resPos;
    }

    public void Hide() {
        transform.position = HidePosition;
    }
}
