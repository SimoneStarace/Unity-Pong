using UnityEngine;
using UnityEngine.UI;
public class LinkMenu : MonoBehaviour
{
    #region FIELDS
    //Reference to the buttons.
    [SerializeField]
    private Button _gitHubButton = null,
                   _youtubeButton = null; 
    #endregion

    #region METHODS
#if UNITY_WEBGL
    private void Awake()
    {
        //Disable the buttons for the WEBGL version of the game.
        if (_gitHubButton)
        {
            _gitHubButton.interactable = false;
        }

        if (_youtubeButton)
        {
            _youtubeButton.interactable = false;
        }

    }
#endif
    /// <summary>
    /// Takes an url for open a webpage.
    /// </summary>
    /// <param name="url">The url of the webpage.</param>
    public void OpenWebPageByUrl(string url) => ApplicationManager.Instance?.OpenWebPage(url); 
    #endregion
}
