using UnityEngine;
using Menus;
using Managers;
/// <summary>
/// Class that control the logic of the Game by taking count of the scores.
/// </summary>
public class GameSession : MonoBehaviour
{
    #region FIELDS
    /// <summary>
    /// Reference to the audio clip to play when a player gets a point.
    /// </summary>
    [SerializeField]
    private AudioClip _scoreSound = null;
    /// <summary>
    /// Reference to the player 2.
    /// </summary>
    [SerializeField]
    private Player _player2 = null;
    /// <summary>
    /// The max score for the match.
    /// </summary>
    private readonly int _maxScore = GameManager.MaxScore;

    private int[] _playerScore; //Array of players scores.
    /// <summary>
    /// Reference to the GameUI.
    /// </summary>
    private GameMenu _gameMenu;
    #endregion

    #region METHODS
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        Debug.Log(GameManager.IsPlayer2AIOn + " " + GameManager.AIDiff);
#endif

        CheckPlayer2AISetup();

        _playerScore = new int[2];
        //Index 0 refers to player 2.
        //Index 1 refers to player 1.

        //Find the GameUI Object.
        _gameMenu = FindObjectOfType<GameMenu>();
    }

    /// <summary>
    /// Method for increase the score.
    /// </summary>
    /// <param name="index">The index of the player score.</param>
    public void IncreasePlayerScore(int index)
    {
        //If the score sound isn't null.
        if (_scoreSound && GameManager.IsSoundOn)
        {
            //Play the sound.
            AudioSource.PlayClipAtPoint(_scoreSound, Camera.main.transform.position);
        }
        //Increase the score and check if it's equal or greater than the max score.
        if (++_playerScore[index] >= _maxScore)
        {
            //Remove the players and the ball.
            RemoveObjects();
        }
        //If the Game UI is not null.
        if (_gameMenu)
        {
            //Update the score.
            _gameMenu.UpdatePlayerScore(index, _playerScore[index]);
        }
        //If player 2 has the maximum score
        if (_playerScore[0] >= _maxScore)
        {
            ShowWinner("Player 2");
        }
        //Else-if player 1 has the maximum score
        else if (_playerScore[1] >= _maxScore)
        {
            ShowWinner("Player 1");
        }
    }

    /// <summary>
    /// Method to send which player won the match.
    /// </summary>
    /// <param name="player">The name of the player.</param>
    private void ShowWinner(string player) => _gameMenu?.ShowWinner(player);
    /*
    {
        if (_gameUI)
        {
            //Show the message.
            _gameUI.ShowWinner(player);
        }
    }
    */

    private void CheckPlayer2AISetup()
    {
        //If the player 2 must be controlled by the AI
        if (GameManager.IsPlayer2AIOn)
        {
            //Make the player 2 controlled by AI.
            _player2.IsAIOn = true;

            //Check the difficulty of the AI.
            if (GameManager.AIDiff == GameManager.Difficulty.Easy)
            {
                _player2.SetSpeed(3.5f);
            }
            else if (GameManager.AIDiff == GameManager.Difficulty.Normal)
            {
                _player2.SetSpeed(4.0f);
            }
            else if (GameManager.AIDiff == GameManager.Difficulty.Hard)
            {
                _player2.SetSpeed(5.5f);
            }
        }
    }

    /// <summary>
    /// Method for remove the players and the ball.
    /// </summary>
    private void RemoveObjects()
    {
        //Find every player component inside the objects in the scene.
        foreach (Player p in GameObject.FindObjectsOfType<Player>())
        {
            //Destroy the gameobjects.
            Destroy(p.gameObject);
        }
        //Find the ball object and destroy it.
        Destroy(GameObject.FindObjectOfType<Ball>().gameObject);
    } 
    #endregion
}