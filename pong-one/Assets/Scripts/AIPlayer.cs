using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    Paddle paddle;
    public Rigidbody2D ball;
    private Rigidbody2D rb;

    public float moveSpeed = 10f;

    void Start()
    {
        paddle = GetComponent<Paddle>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
{
    if (ball.transform.localPosition.x >= 0 && ball.velocity.x > 0)
    {
        // Move the paddle towards the ball's y-position
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, ball.transform.position.y, transform.position.z), Time.deltaTime * moveSpeed);

        // Clamp the paddle's y-position to the screen boundaries
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, -455, 455), transform.localPosition.z);
    }
}
}
