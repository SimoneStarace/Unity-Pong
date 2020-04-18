using UnityEngine;
using TMPro;
namespace Menus
{

    public class WinnerMenu : MonoBehaviour
    {
        /// <summary>
        /// Reference to the winner text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI _winnerText = null;
        /// <summary>
        /// Set the text of the Winner Text field.
        /// </summary>
        /// <param name="text">The text to show.</param>
        public void SetWinnerText(string text) 
        {
            if(_winnerText)
            {
                _winnerText.text = text;
            }
        }
    } 
}