using UnityEngine;
/// <summary>
/// Class for detect who make a point.
/// </summary>
public class Wall : MonoBehaviour
{
    #region FIELDS
    private enum Direction { Left, Right }
    /// <summary>
    /// The direction of the wall for reset the ball.
    /// </summary>
    [SerializeField]
    private Direction _direction = Direction.Left;
    /// <summary>
    /// Reference to the GameSession object.
    /// </summary>
    private GameSession _gameSession;
    #endregion

    #region METHODS
    private void Start()
    {
        //Get the GameSession object.
        _gameSession = GameObject.FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Try getting the Ball component.
        if (other.TryGetComponent(out Ball b))
        {
            //Get the value of the direction in integer.
            int indexDirection = (int)_direction;
            /* If the object GameSession isn't null.
            if(_gameSession)
            {
                //Tell to increase the score to a specific player.
                _gameSession.IncreasePlayerScore(indexDirection);
            }
            */
            _gameSession?.IncreasePlayerScore(indexDirection);
            //Reset the ball position.
            b.Reset(indexDirection);
        }
    } 
    #endregion
}