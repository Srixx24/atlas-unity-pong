using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public const int WinningScore = 11;
    public GameObject EndGameAnnouncement;
    public TextMeshProUGUI playerOneScoreText;
    public TextMeshProUGUI playerTwoScoreText;
    public TextMeshProUGUI FinalScore;
    public ScoreKeeper scoreKeeper;


    private void Start()
    {
        scoreKeeper = GetComponent<ScoreKeeper>();

        scoreKeeper.playerOneScore = playerOneScoreText;
        scoreKeeper.playerTwoScore = playerTwoScoreText;

        scoreKeeper.onScoreChanged.AddListener(OnScoreChanged);
    }

    public void Update()
    {
        scoreKeeper.GoalCheck();
    }

    private void OnScoreChanged(int playerOneScore, int playerTwoScore)
    {
        CheckWinningCondition(playerOneScore, playerTwoScore);
    }

    // Checks for 11 points
    private void CheckWinningCondition(int playerOneScore, int playerTwoScore)
    {
        

        if (playerOneScore >= WinningScore)
        {
            EndGame("Player One", "Player Two");
        }
        else if (playerTwoScore >= WinningScore)
        {
            EndGame("Player Two", "Player One");
        }
    }

    private void EndGame(string winner, string loser)
    {
        // Freeze the game
        Time.timeScale = 0f;

        // Show the end game canvas
        EndGameAnnouncement.SetActive(true);

        // Display the final scores
        playerOneScoreText.text = playerOneScoreText.text;
        playerTwoScoreText.text = playerTwoScoreText.text;
        FinalScore.text = $"{winner} is the Victor!\n{loser} has been defeated!";
    }
}
