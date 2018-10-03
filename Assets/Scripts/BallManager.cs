using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public int BallCount;
    public Ball BallPrefab;
    private Queue<Ball> _balls;

	// Use this for initialization
	void Start () {
        _balls = new Queue<Ball>(BallCount);
		for (int i = 0; i < BallCount; i++)
        {
            var ball = Instantiate<Ball>(BallPrefab);
            ball.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            _balls.Enqueue(ball);
        }
	}
	
    public Ball AquireBall()
    {
        var ball = _balls.Dequeue();
        ball.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        return ball;
    }

    public void ReleaseBall(Ball ball)
    {
        ball.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        _balls.Enqueue(ball);
    }
}
