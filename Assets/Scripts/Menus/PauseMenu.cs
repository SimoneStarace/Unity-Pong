using UnityEngine;
using Managers;
namespace Menus
{
    public class PauseMenu : MonoBehaviour
    {
        /// <summary>
        /// Reference to the LevelManager.
        /// </summary>
        [SerializeField]
        private LevelManager _levelManager = null;

        #region METHODS
        /// <summary>
        /// When the game object is enabled.
        /// </summary>
        private void OnEnable() => Time.timeScale = 0.0f;
        /// <summary>
        /// When the game object is disabled.
        /// </summary>
        private void OnDisable() => Time.timeScale = 1.0f;
        /// <summary>
        /// On Resume Button Pressed.
        /// </summary>
        public void OnResumeButtonPressed() => gameObject.SetActive(false);
        /// <summary>
        /// On Return Button Pressed.
        /// </summary>
        public void OnReturnButtonPressed()
        {
            //Reset the timescale.
            Time.timeScale = 1.0f;
            //Load the scene.
            _levelManager?.LoadScene("MainMenu");
        } 
        #endregion
    } 
}