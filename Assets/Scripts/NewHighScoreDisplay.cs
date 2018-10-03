using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewHighScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private GameManager gameManager;
    private SoundsManager soundsManager;
    private bool playedOnce = false;

    void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
        _text = GetComponent<TextMeshProUGUI>();
        _text.enabled = false;
	}
	
	void Update ()
    {
		if (gameManager.newHighScore && !playedOnce)
        {
            _text.enabled = true;
            soundsManager.PlayAlarm4();
            playedOnce = true;
        }
	}
}
