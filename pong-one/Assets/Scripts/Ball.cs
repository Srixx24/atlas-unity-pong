using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 initialPosition;
    private Rigidbody2D rb;
    public float speed = 500f;
    public float accelerationRate = 0.1f;
    public float maxSpeed = 5000f;
    public Vector3 velocity;
    private AudioSource audioSource;
    public AudioClip paddleSound;
    public AudioClip borderSound;
    private float pitchRange = 0.4f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //initialPosition = transform.position;

        AddForce();

        // Set the initial velocity of the ball
        velocity = new Vector3(speed, 0f, 0f);

        audioSource = GetComponent<AudioSource>();

    }

    public void AddForce()
    {
        /* The AddForce() method applies an initial force to the ball in a random 
        * direction. This ensures that the ball starts moving in a different direction 
        * each time the game is played.
        */
        float angle = Random.value < 0.5f ? -1f : 1f;
        float force = Random.value < 0.5f ? Random.Range(-10f, -0.8f) : Random.Range(0.8f, 10f);

        Vector2 direction = new Vector2(angle, force);
        rb.AddForce(direction * this.speed);
    }

    void Update()
    {
        // Maintain a constant ball speed
        rb.velocity = rb.velocity.normalized * speed;

        // Increase the ball's speed over time
        IncreaseSpeed();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the ball collided with a paddle or a goal
        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Border"))
        {
            // Play the impact sound effect
            PlayImpactSound(collision);
        }
    }

    private void IncreaseSpeed()
    {
        // Increase the ball's velocity
        velocity *= (1 + accelerationRate * Time.deltaTime);

        // Limit the ball's speed to the maximum speed
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
    }

    private void PlayImpactSound(Collision2D collision)
    {
        // Randomize the pitch of the audio source
        audioSource.pitch = Random.Range(1.0f - pitchRange, 1.0f + pitchRange);

        if (collision.gameObject.CompareTag("Paddle"))
        {
            audioSource.clip = paddleSound;
        }
        else if (collision.gameObject.CompareTag("Border"))
        {
            audioSource.clip = borderSound;
        }

        audioSource.Play();
    }

    public void ResetBall()
    {
        /* The ResetBall() method is responsible for resetting the ball's
        * position and velocity when the game is restarted or a point is
        * scored. It sets the ball's velocity to zero, moves the ball back to
        * its initial position, and then applies a new random force to the ball
        * using the AddForce() method.
        */
        rb.velocity = Vector2.zero;
        transform.position = initialPosition;
        AddForce();
    }
}