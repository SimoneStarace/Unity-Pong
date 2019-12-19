using UnityEngine;
/// <summary>
/// Class that let the user or the AI to control the player.
/// </summary>
[RequireComponent(typeof(BoxCollider2D),typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
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
    /// <summary>
    /// Property for make the AI react faster.
    /// </summary>
    public float AISpeedReaction { get; set; } = 2.0f;

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
        if(!IsAIOn)
        {
            //The player controls the racket.
            transform.Translate(new Vector3(0, Input.GetAxis(_axisInputName) * _speed * Time.deltaTime, 0.0f));
        }
        else //The AI controls the racket.
        {
            //If the y component is different from the ball.
            if(transform.position.y != _ball.transform.position.y)
            {
                //Tell the new position to the player.
                transform.position = new Vector2(transform.position.x, Vector2.MoveTowards(transform.position, _ball.transform.position, (_speed*AISpeedReaction) * Time.deltaTime).y);
            }
        }

        //If both transform components aren't null then check the position.
        if(_topWall && _bottomWall)
        {
            //Change the position
            transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, _bottomWall.position.y + (transform.localScale.y-1), _topWall.position.y - (transform.localScale.y-1)));
        }
    }
}