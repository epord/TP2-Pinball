using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public string BallResetKey = "ResetBallKey";
    public Vector3 resPos;

    public Vector3 initialVelocity;
    private Rigidbody _rigidBody;

    void Start ()
    {
        resPos = transform.position;
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.velocity = initialVelocity;
        //door = GameObject.Find("Map/Door").GetComponent<Door>();
    }
	
	void Update ()
    {
        // Reset ball position when it falls from the map
        if (transform.position.z < -3.5)
        {
            transform.position = resPos;
        }

        // Close the door when lauching is down, open it for new launch
        // USE POSITION, 3.5 IS JUST AN APPORXIMATION FOR THE TEST

        if (!_rigidBody.isKinematic && Input.GetButton(BallResetKey)) {
            ResetPosition();
        }
        //if (transform.position.x >= -3.5 && door.opened)
        //{
        //    door.Close();
        //}
        //else if (transform.position.x < -3.5 && !door.opened)
        //{
        //    door.Open();
        //}
    }

    public void ResetPosition() {
        transform.position = resPos;
        _rigidBody.velocity = initialVelocity;
    }
}
