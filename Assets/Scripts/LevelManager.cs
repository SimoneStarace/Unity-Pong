using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Class that takes care for loading scenes.
/// </summary>
public class LevelManager : MonoBehaviour
{
    /// <summary>
    /// Method for load a scene
    /// </summary>
    /// <param name="name">Name of the scene</param>
    public void LoadScene(string name) => SceneManager.LoadScene(name);

    /// <summary>
    /// Method for reload the scene.
    /// </summary>
    public void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    /// <summary>
    /// Close the application
    /// </summary>
    public void CloseApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}