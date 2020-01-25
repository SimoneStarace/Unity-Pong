using UnityEngine;
/// <summary>
/// Class that let the user or the AI to control the player.
/// </summary>
[RequireComponent(typeof(BoxCollider2D),typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    #region FIELDS
    /// <summary>
    /// String that tells which Axis must input the player.
    /// </summary>
    [SerializeField]
    private string _axisInputName = null;
    /// <summary>
    /// The speed movement of the racket.
    /// </summary>
    [SerializeField]
    private float _speed = 4.0f;

    /// <summary>
    /// Reference to the transform of the wall.
    /// </summary>
    [SerializeField]
    private Transform _topWall = null,
                      _bottomWall = null;
    /// <summary>
    /// The reference to the ball gameobject.
    /// </summary>
    private Ball _ball = null;
    /// <summary>
    /// Property for tell if the player is controlled by AI.
    /// </summary>
    public bool IsAIOn { private get; set; } = false; 
    #endregion

    #region METHODS

    /// <summary>
    /// Updates the speed of the player.
    /// </summary>
    /// <param name="_speed">The speed value.</param>
    public void SetSpeed(float _speed)
    {
        this._speed = _speed;
    }

    private void Start()
    {
        //Find the reference to the ball.
        _ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //Call the Move method.
        Move();
    }

    /// <summary>
    /// Method for move the player.
    /// </summary>
    private void Move()
    {
        //If the AI is not on.
        if (!IsAIOn)
        {
            //The player controls the racket.
            UpdatePosition(Input.GetAxis(_axisInputName));
        }
        else //The AI controls the racket.
        {
            //Local difference between the paddle and the ball on the y direction.
            float yDiff;
            //If the absolute difference between the paddle and the ball is greater or equal to 1.
            if (Mathf.Abs(yDiff = transform.position.y - _ball.transform.position.y) > 0.5f)
            {
                /*Tell the new position to the AI.
                 * -1 Moves UP.
                 * 1 Moves DOWN.
                 */
                UpdatePosition((yDiff > 0.5f ? -1 : 1));
            }
        }

        //If both transform components aren't null then check the position.
        if (_topWall && _bottomWall)
        {
            //Change the position
            transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, _bottomWall.position.y + (transform.localScale.y - 1), _topWall.position.y - (transform.localScale.y - 1)));
        }
    }

    /// <summary>
    /// Update the Y position of the player
    /// </summary>
    /// <param name="direction"></param>
    private void UpdatePosition(float direction)
    {
        //The player controls the racket.
        transform.Translate(new Vector3(0, direction * _speed * Time.deltaTime, 0.0f));
    } 
    #endregion
}