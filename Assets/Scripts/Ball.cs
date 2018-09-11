using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 resPos;
    private Door door;

    void Start ()
    {
        resPos = transform.position;
        door = GameObject.Find("Map/Door").GetComponent<Door>();
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
        if (transform.position.x >= -3.5 && door.opened)
        {
            door.Close();
        }
        else if (transform.position.x < -3.5 && !door.opened)
        {
            door.Open();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bumper")
        {
            float bumpForce = collision.gameObject.GetComponent<Bumpers>().bumpForce;
            Vector3 dir = transform.position - collision.transform.position;
            dir.Normalize();
            GetComponent<Rigidbody>().AddForce(dir * bumpForce);
        }
    }
}
