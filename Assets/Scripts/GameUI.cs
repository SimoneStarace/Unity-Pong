using UnityEngine;
using TMPro;
/// <summary>
/// Class that control the Game UI.
/// </summary>
public class GameUI : MonoBehaviour
{
    /// <summary>
    /// Reference to the player scores texts.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI[] _playerUIScores = null;
    /// <summary>
    /// Reference to the winner text.
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI _winnerText = null;
    /// <summary>
    /// Reference to the Winner screen object.
    /// </summary>
    [SerializeField]
    private GameObject _winnerUI = null;

    private void Start()
    {
        /*if the winner screen isn't null.
        if(_winnerUI)
        {
            //Disable it.
            _winnerUI.SetActive(false);
        }
        */
        _winnerUI?.SetActive(false);
    }
    /// <summary>
    /// Method for update the score text
    /// </summary>
    /// <param name="index">The index of the player</param>
    /// <param name="value">The score value of the player based on the index value</param>
    public void UpdatePlayerScore(int index,int value)
    {
        //If the player score text isn't null
        if(_playerUIScores[index])
        {
            //Change the text value.
            _playerUIScores[index].text = value.ToString();
        }
    }
    /// <summary>
    /// Method for show the winner
    /// </summary>
    /// <param name="winnerPlayer">The player who won the match.</param>
    public void ShowWinner(string winnerPlayer)
    {
        if(_winnerText)
        {
            //Show the text.
            _winnerText.text = winnerPlayer + "\nwins";
        }
        /*
        if(_winnerUI)
        {
            //Show the winner screen.
            _winnerUI.SetActive(true);
        }
        */
        _winnerUI?.SetActive(true);
        
    }
}
