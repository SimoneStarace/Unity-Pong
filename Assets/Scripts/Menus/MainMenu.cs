using UnityEngine;
using Managers;
namespace Menus
{
    /// <summary>
    /// Class that control the UI of the main menu.
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        #region FIELDS
        /// <summary>
        /// //Reference to the first screen.
        /// </summary>
        [SerializeField]
        private GameObject _startScreen = null;
        /// <summary>
        /// Reference to the TextMeshPro text object.
        /// </summary>
        [SerializeField]
        private TMPro.TextMeshProUGUI _versionText = null,
                                      _authorText = null; 
        #endregion

        #region METHODS
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
                _authorText.text = "Made by <b>" + ApplicationManager.Instance?.GetCompanyName() + "</b>.";
            }

            if (_versionText)
            {
                _versionText.text = "Version: <b>" + ApplicationManager.Instance?.GetVersion() + "</b>";
            }
        } 
        #endregion
    } 
}