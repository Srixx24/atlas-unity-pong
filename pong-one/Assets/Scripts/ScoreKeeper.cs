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
    public TextMeshProUGUI scoreText;
    private int playerOnePoints = 0;
    private int playerTwoPoints = 0;
    public int score = 0;
    public UnityEvent<int> onScoreChanged;

    public void GoalCheck()
    {
        Collider2D[] goalColliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (Collider2D collider in goalColliders)
        {
            if (collider.gameObject.CompareTag("LeftGoal"))
            {
                IncreasePlayerTwoScore();
                ball.ResetBall();
            }
            else if (collider.gameObject.CompareTag("RightGoal"))
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
        onScoreChanged.Invoke(playerOnePoints);
    }

    public void IncreasePlayerTwoScore()
    {
        playerTwoPoints++;
        UpdateScoreText();
        onScoreChanged.Invoke(playerOnePoints);
    }

    //check
    private void UpdateScoreText()
    {
        playerOneScore.text = playerOnePoints.ToString();
        playerTwoScore.text = playerTwoPoints.ToString();
        scoreText.text = $"{playerOnePoints} - {playerTwoPoints}";
    }

    public void ResetScore()
    {
        score = 0;
        onScoreChanged.Invoke(score);
        UpdateScoreText();
    }
}
