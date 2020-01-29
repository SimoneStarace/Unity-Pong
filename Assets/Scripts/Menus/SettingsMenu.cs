using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Managers;
namespace Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        #region FIELDS
        /// <summary>
        /// Reference to the InputField
        /// </summary>
        [SerializeField]
        private TMP_InputField _inputMaxScoreField = null;
        /// <summary>
        /// Reference to the dropdown list.
        /// </summary>
        [SerializeField]
        private TMP_Dropdown _framerateDropdown = null;
        /// <summary>
        /// Reference to the Toggle.
        /// </summary>
        [SerializeField]
        private Toggle _soundToggle = null;
        #endregion

        #region METHODS
        private void Awake()
        {
            if (_inputMaxScoreField)
            {
                //Set the value of the InputField based on the GameManager Max Score.
                _inputMaxScoreField.text = GameManager.MaxScore.ToString();
            }

            if (_soundToggle)
            {
                //Set the sound toggle based on the value of the Sound Manager.
                _soundToggle.isOn = GameManager.IsSoundOn;
            }
        }
        /// <summary>
        /// Sets the max score for the GameManager
        /// </summary>
        /// <param name="value"></param>
        public void OnMaxScoreFieldEndChange(string value)
        {
            //Specify the new MaxScore.
            GameManager.MaxScore = Mathf.Clamp(int.Parse(value), 1, 99);
            //If the inputfield is not null and the value of the input field is different from the max score of the game manager.
            if(_inputMaxScoreField && int.Parse(_inputMaxScoreField.text) != GameManager.MaxScore)
            {
                //Updated the input field.
                _inputMaxScoreField.text = GameManager.MaxScore.ToString();
            }
        }
        /// <summary>
        /// Sets the framerate of the game.
        /// </summary>
        public void OnFramerateOptionChange(int value)
        {
            if (_framerateDropdown)
            {
                ApplicationManager.Instance?.SetFramerate(int.Parse(_framerateDropdown.options[value].text));
            }
        }
        /// <summary>
        /// Sets the sound check.
        /// </summary>
        /// <param name="value"></param>
        public void OnSoundToggleChange(bool value) => GameManager.IsSoundOn = value; 
        #endregion
    } 
}