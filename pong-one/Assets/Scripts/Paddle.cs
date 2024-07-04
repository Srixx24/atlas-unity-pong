using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 500f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveVertically(float direction)
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(0, direction * speed);
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on Paddle object.");
        }
    }
}