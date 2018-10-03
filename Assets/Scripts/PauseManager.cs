using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isGamePaused = false;
    private SoundsManager soundsManager;

    // UI variables
    public GUISkin skin;
    private float menuCoordX = 0.35f;
    private float menuCoordY = 0.15f;
    private float menuWidth = 0.36f;
    private float menuHeight = 0.5f;
    private float buttonWidth = 0.3f;
    private float buttonHeight = 0.15f;
    private float allButtonsPosX = 0.39f;
    private float firstButtonPosY = 0.27f;
    private float secondButtonPosY = 0.47f;

    void Start ()
    {
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isGamePaused)
            {
                Time.timeScale = 0;
                isGamePaused = true;
            }
            else if (isGamePaused)
            {
                Time.timeScale = 1;
                isGamePaused = false;
            }
        }
    }

    private void OnGUI()
    {
        if (isGamePaused)
        {
            GUI.skin = skin;
            GUI.Box(new Rect(Screen.width * menuCoordX, Screen.height * menuCoordY, Screen.width * menuWidth, Screen.height * menuHeight), "Pause");
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * firstButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Resume", "Resume")))
            {
                soundsManager.PlayButtonClick();
                Time.timeScale = 1;
                isGamePaused = false;
            }
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * secondButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Menu", "Menu")))
            {
                soundsManager.PlayButtonClick();
                Time.timeScale = 1;
                Application.LoadLevel("MenuTests");
            }
        }
    }
}
