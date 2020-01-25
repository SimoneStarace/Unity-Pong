using UnityEngine;
using Managers;
namespace Menus
{
    public class PlayMenu : MonoBehaviour
    {
        /// <summary>
        /// Method for set the AI for player 2.
        /// </summary>
        /// <param name="value">The value of the option</param>
        public void SetGameManagerAI(bool value) => GameManager.IsPlayer2AIOn = value;

        /// <summary>
        /// Method for set the difficulty of the AI.
        /// </summary>
        /// <param name="value">The value of the difficulty</param>
        public void SetGameManagerAIDifficulty(int value)
        {
            GameManager.Difficulty diff = (GameManager.Difficulty)value;
            //If the value is less or equal to the last value in the enum.
            if (diff <= GameManager.Difficulty.Hard)
            {
                //Assign the difficulty.
                GameManager.AIDiff = diff;
            }
        }
    } 
}