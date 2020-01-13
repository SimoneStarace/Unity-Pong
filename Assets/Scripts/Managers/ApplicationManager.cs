using UnityEngine;
/// <summary>
/// Manager that takes care of the Application
/// </summary>
public class ApplicationManager : MonoBehaviour
{
    public static ApplicationManager Instance { get; private set; }

    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
            Instance.transform.SetParent(null);
            Instance.SetFramerate();
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Get the version of the game.
    /// </summary>
    /// <returns></returns>
    public string GetVersion()
    {
        return Application.version;
    }
    /// <summary>
    /// Get the company name of the game.
    /// </summary>
    /// <returns>The company name.</returns>
    public string GetCompanyName()
    {
        return Application.companyName;
    }
    /// <summary>
    /// Set the framerate of the game.
    /// </summary>
    /// <param name="framerate">The framerate the application should run.</param>
    public void SetFramerate(int framerate = 60)
    {
        Application.targetFrameRate = framerate;
    }
    /// <summary>
    /// Opens a webpage by url.
    /// </summary>
    /// <param name="url">The url of the webpage</param>
    public void OpenWebPage(string url)
    {
        if(!string.IsNullOrEmpty(url) && url.Contains("https://"))
        {
            Application.OpenURL(url);
        }
#if UNITY_EDITOR
        else
        {
            Debug.LogWarning("THE URL IS EMPTY OR NULL!");
        }
#endif
    }
}
