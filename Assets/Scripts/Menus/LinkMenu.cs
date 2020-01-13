using UnityEngine;
public class LinkMenu : MonoBehaviour
{
    /// <summary>
    /// Takes an url for open a webpage.
    /// </summary>
    /// <param name="url">The url of the webpage.</param>
    public void OpenWebPageByUrl(string url) => ApplicationManager.Instance?.OpenWebPage(url);
}
