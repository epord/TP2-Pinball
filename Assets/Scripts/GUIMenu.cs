using UnityEngine;

public class GUIMenu : MonoBehaviour
{
    private bool mainMenu = true;
    private bool play = false;
    private bool highScores = false;
    private bool controls = false;
    public GUISkin skin;
    private SoundsManager soundsManager;
    private const string HIGHSCORE = "highScore";
    private int _highScore;

    // UI variables
    public float menuCoordX = 0.5f;
    public float menuCoordY = 0.5f;
    public float menuWidth = 0.3f;
    public float menuHeight = 0.9f;
    public float buttonWidth = 0.4f;
    public float buttonHeight = 0.15f;
    public float allButtonsPosX = 0.3f;
    public float firstButtonPosY = 0.2f;
    public float secondButtonPosY = 0.4f;
    public float thirdButtonPosY = 0.6f;

    private void Start()
    {
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
        soundsManager.PlayRickAndMortyTheme();
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        GUI.Box(new Rect(Screen.width * menuCoordX, Screen.height * menuCoordY, Screen.width * menuWidth, Screen.height * menuHeight), "");

        if (mainMenu)
        {
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * firstButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Play","Play")))
            {
                mainMenu = false;
                play = true;
                soundsManager.PlayButtonClick();
                Application.LoadLevel("MainScene");
            }
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * secondButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("HighScore", "HighScore")))
            {
                mainMenu = false;
                highScores = true;
                soundsManager.PlayButtonClick();
            }
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * thirdButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Controls", "Controls")))
            {
                mainMenu = false;
                controls = true;
                soundsManager.PlayButtonClick();
            }
        }
        else if (highScores)
        {
            _highScore = PlayerPrefs.GetInt(HIGHSCORE);
            GUI.Label(new Rect(Screen.width * allButtonsPosX, Screen.height * firstButtonPosY, Screen.width * buttonWidth, Screen.height * 3 * buttonHeight),
                "Current highscore\n" +
                " is\n" +
                _highScore);
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * thirdButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Return", "Return")))
            {
                mainMenu = true;
                highScores = false;
                soundsManager.PlayButtonClick();
            }
        }
        else if (controls)
        {
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * thirdButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Return", "Return")))
            {
                mainMenu = true;
                controls = false;
                soundsManager.PlayButtonClick();
            }
            GUI.Label(new Rect(Screen.width * allButtonsPosX, Screen.height * firstButtonPosY, Screen.width * buttonWidth, Screen.height * 3 * buttonHeight),
                "New Life : R\n" +
                "Flipper Left : F\n" +
                "Flipper Right : J\n" +
                "Launch Ball : Space\n" +
                "Pause Game : P");
        }
    }

    public bool GetPlayState()
    {
        return play;
    }
}
