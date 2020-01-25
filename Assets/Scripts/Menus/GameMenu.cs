using UnityEngine;
using TMPro;
namespace Menus
{
    /// <summary>
    /// Class that control the Game UI.
    /// </summary>
    public class GameMenu : MonoBehaviour
    {
        #region FIELDS
        /// <summary>
        /// Reference to the player scores texts.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI[] _playerUIScores = null;
        /// <summary>
        /// Reference to the pause Menu.
        /// </summary>
        [SerializeField]
        private PauseMenu _pauseMenu = null;
        /// <summary>
        /// Reference to the Winner screen object.
        /// </summary>
        [SerializeField]
        private WinnerMenu _winnerMenu = null; 
        #endregion

        #region METHODS
        private void Start()
        {
            /*if the winner screen isn't null.
            if(_winnerUI)
            {
                //Disable it.
                _winnerUI.SetActive(false);
            }
            */
            _winnerMenu?.gameObject.SetActive(false);
            _pauseMenu?.gameObject.SetActive(false);
        }
        /// <summary>
        /// Enable the pause menu.
        /// </summary>
        public void OnPauseButtonPressed() => _pauseMenu?.gameObject.SetActive(true);
        /// <summary>
        /// Method for update the score text
        /// </summary>
        /// <param name="index">The index of the player</param>
        /// <param name="value">The score value of the player based on the index value</param>
        public void UpdatePlayerScore(int index, int value)
        {
            //If the player score text isn't null
            if (_playerUIScores[index])
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
            if (_winnerMenu)
            {
                //Show the text.
                _winnerMenu.SetWinnerText(winnerPlayer + "\nwins");
            }
            /*
            if(_winnerUI)
            {
                //Show the winner screen.
                _winnerUI.SetActive(true);
            }
            */
            _winnerMenu?.gameObject.SetActive(true);
        } 
        #endregion
    } 
}