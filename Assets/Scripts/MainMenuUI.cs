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

    private void Start()
    {

        //If the start screen isn't null.
        if(_startScreen)
        {
            //Activate it.
            _startScreen.SetActive(true);

            #if UNITY_WEBGL
                //Disable the exit button.
                GameObject.Find("Exit Button").SetActive(false);
            #endif
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
}