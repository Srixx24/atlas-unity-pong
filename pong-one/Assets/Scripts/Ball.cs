using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector2 ballDirection;
    public float ballSpeed = 800f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //initialPosition = transform.position;

        AddForce();
    }

    private void AddForce()
    {
        // Apply an initial force in a random direction
        float angle = Random.value < 0.5f ? -1f : 1f;
        float force = Random.value < 0.5f ? Random.Range(-10f, -0.1f) : Random.Range(0.1f, 10f);

        Vector2 direction = new Vector2(angle, force);
        rb.AddForce(direction * this.ballSpeed);
    }

    void Update()
    {
        // Maintain a constant ball speed
        rb.velocity = rb.velocity.normalized * ballSpeed;
    }
    public void ResetBall()
    {
        // Stop the ball and reset its position
        rb.velocity = Vector2.zero;
        transform.position = initialPosition;
        AddForce();
    }
}