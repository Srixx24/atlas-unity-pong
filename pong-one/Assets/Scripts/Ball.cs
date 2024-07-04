using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialForceMin = 5f;
    public float initialForceMax = 10f;
    public float ballSpeed = 5f;

    private Rigidbody2D rb;
    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;

        // Apply an initial force in a random direction
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float force = Random.Range(initialForceMin, initialForceMax);
        rb.AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * force, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        // Maintain a constant ball speed
        rb.velocity = rb.velocity.normalized * ballSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reverse the ball's velocity when it collides with a paddle
        if (collision.gameObject.CompareTag("Paddle"))
        {
            rb.velocity = -rb.velocity;
        }
    }

    public void ResetBall()
    {
        // Stop the ball and reset its position
        rb.velocity = Vector2.zero;
        transform.position = initialPosition;
    }
}