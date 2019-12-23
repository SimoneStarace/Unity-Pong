using UnityEngine;
/// <summary>
/// Class that control the UI of the main menu.
/// </summary>
public class MainMenuUI : MonoBehaviour
{
    /// <summary>
    /// Reference to the first screen
    /// </summary>
    [SerializeField]
    private GameObject _startScreen = null;
    /// <summary>
    /// Reference to the TextMeshPro text object.
    /// </summary>
    [SerializeField]
    private TMPro.TextMeshProUGUI _versionText = null,
                                  _authorText = null;

    private void Start()
    {

        //If the start screen isn't null.
        if (_startScreen)
        {
            //Activate it.
            _startScreen.SetActive(true);

#if UNITY_WEBGL
            //Disable the exit button.
            GameObject.Find("Exit Button").SetActive(false);
#endif
        }

        CheckUIText();
    }

    /// <summary>
    /// Check if the TextMeshPro components are not null and if not update it.
    /// </summary>
    private void CheckUIText()
    {
        if (_authorText)
        {
            _authorText.text = "Made by <b>" + ApplicationManager.GetCompanyName() + "</b>.";
        }

        if (_versionText)
        {
            _versionText.text = "Version: <b>" + ApplicationManager.GetVersion() + "</b>";
        }
    }

    /// <summary>
    /// Method for set the AI for player 2.
    /// </summary>
    /// <param name="value">The value of the option</param>
    public void SetGameManagerAI(bool value)
    {
        //Assign the value to the GameManager.
        GameManager.IsPlayer2AIOn = value;
    }
    /// <summary>
    /// Method for set the difficulty of the AI.
    /// </summary>
    /// <param name="value">The value of the difficulty</param>
    public void SetGameManagerAIDifficulty(int value)
    {
        //If the value is less or equal to the last value in the enum.
        if((GameManager.Difficulty)value <= GameManager.Difficulty.Hard)
        {
            //Assign the difficulty.
            GameManager.AIDiff = (GameManager.Difficulty)value;
        }
    }

    /// <summary>
    /// Takes an url for open a webpage.
    /// </summary>
    /// <param name="url">The url of the webpage.</param>
    public void OpenWebPageByUrl(string url)
    {
        ApplicationManager.OpenWebPage(url);
    }
}