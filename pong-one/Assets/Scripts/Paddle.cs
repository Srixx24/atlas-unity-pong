using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float moveSpeed = 10f;

    private Transform paddleTransform;

    private void Start()
    {
        paddleTransform = transform;
    }

    public void MoveVertically(float direction)
    {
        // Move the paddle based on the direction
        paddleTransform.Translate(Vector3.up * direction * moveSpeed * Time.deltaTime);
    }
}