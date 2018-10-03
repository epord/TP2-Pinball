using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    public bool isGameOver = false;
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

    void Start()
    {
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
    }

    private void OnGUI()
    {
        if (isGameOver)
        {
            Time.timeScale = 0;
            GUI.skin = skin;
            GUI.Box(new Rect(Screen.width * menuCoordX, Screen.height * menuCoordY, Screen.width * menuWidth, Screen.height * menuHeight), "Game Over");
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * firstButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("New Game", "New Game")))
            {
                soundsManager.PlayButtonClick();
                Time.timeScale = 1;
                isGameOver = false;
                Application.LoadLevel("GravityTest");
            }
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * secondButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Menu", "Menu")))
            {
                soundsManager.PlayButtonClick();
                Application.LoadLevel("MenuTests");
            }
        }
    }
}
