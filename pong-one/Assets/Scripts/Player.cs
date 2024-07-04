using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;

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
            direction = 10f;
        }
        else if (Input.GetKey(downKey))
        {
            direction = -10f;
        }

        paddle.MoveVertically(direction);
    }
}