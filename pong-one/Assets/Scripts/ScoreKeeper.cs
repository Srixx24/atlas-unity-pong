using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public Ball ball;
    public TextMeshProUGUI playerOneScore;
    public TextMeshProUGUI playerTwoScore;
    private int playerOnePoints = 0;
    private int playerTwoPoints = 0;
    public int score = 0;
    public UnityEvent<int, int> onScoreChanged;


    private void Start()
    {
        UpdateScoreText(playerOnePoints, playerTwoPoints);
    }

    private void OnEnable()
    {
        onScoreChanged.AddListener(UpdateScoreText);
    }

    private void OnDisable()
    {
        onScoreChanged.RemoveListener(UpdateScoreText);
    }

    public void GoalCheck()
    {
        /* The GoalCheck() method is used to detect if the ball has entered either of the two goals.
         * It uses Physics2D.OverlapCircle() to check if there is a collider at the ball's position
         * with the "Goal" tag. If a goal is scored, it calls either IncreasePlayerOneScore() or
         * IncreasePlayerTwoScore() to update the score, and then resets the ball's position.
         */

        Collider2D goalCollider = Physics2D.OverlapCircle(ball.transform.position, 0.5f);
        if (goalCollider != null && goalCollider.CompareTag("Goal"))
        {
            Debug.Log("Goal scored!");
            IncreasePlayerTwoScore();
            ball.ResetBall();
        }
        else
        {
            goalCollider = Physics2D.OverlapCircle(ball.transform.position, 0.5f);
            if (goalCollider != null && goalCollider.CompareTag("Goal"))
            {
                Debug.Log("Goal scored!");
                IncreasePlayerOneScore();
                ball.ResetBall();
            }
        }
    }

    public void IncreasePlayerOneScore()
    {
        playerOnePoints++;
        UpdateScoreText(playerOnePoints, playerTwoPoints);
    }

    public void IncreasePlayerTwoScore()
    {
        playerTwoPoints++;
        UpdateScoreText(playerOnePoints, playerTwoPoints);
    }

    private void UpdateScoreText(int p1Score, int p2Score)
    {
        /* The UpdateScoreText() method updates the text of the playerOneScore and
         * playerTwoScore TextMeshProUGUI components with the current scores for
         * each player.
         */
        playerOneScore.text = $"{p1Score}";
        playerTwoScore.text = $"{p2Score}";
    }

    public void ResetScore()
    {
        score = 0;
        playerOnePoints = 0;
        playerTwoPoints = 0;
        UpdateScoreText(playerOnePoints, playerTwoPoints);
    }
}
