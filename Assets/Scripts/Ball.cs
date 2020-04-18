using UnityEngine;
using Managers;
/// <summary>
/// Class that control the movement of the Ball.
/// </summary>
[RequireComponent(typeof(CircleCollider2D),typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    #region FIELDS
    /// <summary>
    /// The speed movement of the ball.
    /// </summary>
    [SerializeField]
    private float _speed = 7.0f;
    /// <summary>
    /// Attribute for increase the speed of the ball on every collision.
    /// </summary>
    [SerializeField, Range(0.1f, 0.5f)]
    private float _additionalSpeedX = 0.1f;
    /// <summary>
    /// The sound of the ball.
    /// </summary>
    [SerializeField]
    private AudioClip _ballSound = null;
    /// <summary>
    /// The rigidbody 2d component of the ball.
    /// </summary>
    private Rigidbody2D _rigidBody2D;
    #endregion

    #region METHODS
    // Start is called before the first frame update
    void Start()
    {
        //Get the rigidbody component.
        _rigidBody2D = GetComponent<Rigidbody2D>();
        //Reset the position of the ball.
        Reset(Random.Range(0, 2));
    }
    /// <summary>
    /// On every collision 2D
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        //If the sound attribute is not null.
        if (_ballSound && GameManager.IsSoundOn)
        {
            //Play the sound.
            AudioSource.PlayClipAtPoint(_ballSound, Camera.main.transform.position);
        }
        //Local variable for adding the velocity on the y direction.
        float yDirectionVelocity = 0.0f;
        //If the other object is a player.
        if (other.gameObject.CompareTag("Player"))
        {
            //Add the y direction based on the position of the collision of the player racket.
            yDirectionVelocity = (other.GetContact(0).point.y - other.gameObject.transform.position.y) * 2;

#if UNITY_EDITOR
            Debug.Log("yDirectionVelocity: " + yDirectionVelocity);
#endif
        }
        //Add the velocity to the rigidbody component.
        _rigidBody2D.velocity += new Vector2(_rigidBody2D.velocity.x > 0 ? _additionalSpeedX : -_additionalSpeedX, yDirectionVelocity);
    }

    /// <summary>
    /// Method for reset the ball position
    /// </summary>
    public void Reset(int random) => StartCoroutine(ReLaunch(random));

    /// <summary>
    /// Coroutine for Launch the ball.
    /// </summary>
    /// <param name="direction">Value that specify where to launch the ball.</param>
    /// <returns></returns>
    private System.Collections.IEnumerator ReLaunch(int direction)
    {
        //Set the velocity to zero.
        _rigidBody2D.velocity = Vector2.zero;
        //Do not take in count the physic system.
        _rigidBody2D.simulated = false;
        //Set the position based on who made the last point.
        transform.position = Vector2.zero + (direction == 0 ? Vector2.left : Vector2.right);
        //Wait for 3 seconds.
        yield return new WaitForSeconds(3.0f);
        //Take in count the physic system.
        _rigidBody2D.simulated = true;
        //Assign the velocity based on who made the last point.
        // -speed will go to player 1, speed will go to player 2.
        _rigidBody2D.velocity = new Vector2(direction == 0 ? -_speed : _speed, 0.0f);
    } 
    #endregion
}