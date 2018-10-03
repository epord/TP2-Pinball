using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public int BallCount;
    public int TotalBallCount;
    public Ball BallPrefab;
    private Queue<Ball> _balls;
    private int _ballsLeft;
    private bool _newBall;
    private ScoreManager _scoreManager = ScoreManager.GetInstance();

	// Use this for initialization
	void Start () {
        _balls = new Queue<Ball>(BallCount);
        _ballsLeft = TotalBallCount;
		for (int i = 0; i < BallCount; i++)
        {
            var ball = Instantiate<Ball>(BallPrefab);
            ball.Hide();
            ball.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            _balls.Enqueue(ball);
        }
        AquireBall();
	}

    void Update () {
        if (_scoreManager.AddBall()) {
            _ballsLeft++;
            _newBall = true;
        }
    }
	
    public Ball AquireBall()
    {
        var ball = _balls.Dequeue();
        ball.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        ball.ResetPosition();
        return ball;
    }

    public void ReleaseBall(Ball ball)
    {
        ball.Hide();
        ball.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        _balls.Enqueue(ball);
    }

    public void LoseBall()
    {
        _ballsLeft--;
        if (BallsLeft()) {
            AquireBall();
        }
    }

    public bool BallsLeft() {
        return _ballsLeft > 0;
    }

    public int BallsLeftCount() 
    {
        return _ballsLeft;
    }

    public bool NewBall() {
        if (_newBall) {
            _newBall = false;
            return true;
        }
        return false;
    }
}
