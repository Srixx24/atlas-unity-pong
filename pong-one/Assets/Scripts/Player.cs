using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public float moveSpeed = 10f;

    private Paddle paddle;

    void Start()
    {
        paddle = GetComponent<Paddle>();
    }

    void Update()
    {
        float direction = 0f;

        if (Input.GetKey(upKey))
        {
            direction = 1f;
        }
        else if (Input.GetKey(downKey))
        {
            direction = -1f;
        }

        paddle.MoveVertically(direction * moveSpeed);
    }
}