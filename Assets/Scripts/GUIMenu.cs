using UnityEngine;

public class GUIMenu : MonoBehaviour {

    private bool mainMenu;
    private bool play;
    private bool highScores;
    public GUISkin skin;

    // UI variables
    private float buttonWidth;
    private float buttonHeight;
    private float menuWidth;
    private float menuHeight;

	void Start () {
        mainMenu = true;
	}

    private void OnGUI()
    {
        GUI.skin = skin;
        GUI.Box(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f), "");

        if (mainMenu)
        {
            // Screen background : Rick & Morty Picture with no text on it // 
            if (GUI.Button(new Rect(Screen.width * 0.3f, Screen.height * 0.3f, Screen.width * 0.4f, Screen.height * 0.2f), "Play"))
            {
                mainMenu = false;
                play = true;
            }
            if (GUI.Button(new Rect(Screen.width * 0.3f, Screen.height * 0.6f, Screen.width * 0.4f, Screen.height * 0.2f), "HighScores"))
            {
                mainMenu = false;
                highScores = true;
            }
        }
        else if (highScores)
        {
            if (GUI.Button(new Rect(Screen.width * 0.3f, Screen.height * 0.6f, Screen.width * 0.4f, Screen.height * 0.2f), "Return"))
            {
                mainMenu = true;
                highScores = false;
            }
        }
    }

    public bool GetPlayState()
    {
        return play;
    }
}
