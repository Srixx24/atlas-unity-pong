using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public Ball ball;
    public const int WinningScore = 11;
    public TextMeshProUGUI playerOneScore;
    public TextMeshProUGUI playerTwoScore;
    private int playerOnePoints = 0;
    private int playerTwoPoints = 0;
    public int score = 0;
    public UnityEvent<int, int> onScoreChanged;

    public void GoalCheck()
    {
        Collider2D[] goalColliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D collider in goalColliders)
        {
            if (collider.gameObject.CompareTag("Goal"))
            {
                IncreasePlayerTwoScore();
                ball.ResetBall();
            }
            else if (collider.gameObject.CompareTag("Goal"))
            {
                IncreasePlayerOneScore();
                ball.ResetBall();
            }
        }
    }

    public void IncreasePlayerOneScore()
    {
        playerOnePoints++;
        UpdateScoreText();
        onScoreChanged.Invoke(playerOnePoints, playerTwoPoints);
    }

    public void IncreasePlayerTwoScore()
    {
        playerTwoPoints++;
        UpdateScoreText();
        onScoreChanged.Invoke(playerOnePoints, playerTwoPoints);
    }

    // Updates Players scores
    private void UpdateScoreText()
    {
        playerOneScore.text = $"{playerOnePoints}";
        playerTwoScore.text = $"{playerTwoPoints}";
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
        onScoreChanged.Invoke(playerOnePoints, playerTwoPoints);
    }
}
