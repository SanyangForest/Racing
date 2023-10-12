using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PenguinController[] penguins;
    public Text gameStatusText;
    public Text balanceText;
    private int balance = 100;
    private int winningPenguin;
    private bool isGameActive = false;
    public static GameManager instance;

    enum GameState
    {
        NotStarted,
        InProgress,
    }

    private GameState gameState = GameState.NotStarted;

    void Start()
    {
        gameStatusText.text = "Press the Start Button";
        balanceText.text = "Balance: $" + balance;
        winningPenguin = Random.Range(0, penguins.Length);
    }

    public void StartGame()
    {
        if (gameState == GameState.NotStarted)
        {
            gameStatusText.text = "Game in Progress";
            isGameActive = true;
            gameState = GameState.InProgress;

            foreach (PenguinController penguin in penguins)
            {
                penguin.ResetPosition();
                penguin.ActivatePenguin();
                penguin.RandomizeSpeed();
            }
        }
        else if (gameState == GameState.InProgress)
        {
            // 게임이 이미 시작 중인 경우, 버튼 클릭 시 재시작
            RestartGame();
        }
    }

    public void PlaceBet(int betAmount, PenguinController penguin)
    {
        if (gameState == GameState.InProgress && balance >= betAmount)
        {
            balance -= betAmount;
            penguin.SetBetAmount(betAmount);
        }
        else
        {
            Debug.Log("Not enough balance or game not active.");
        }
    }


    public void Reward(int rewardAmount, int penguinNumber)
    {
        balance += rewardAmount;
        UpdateBalanceText();

        if (penguinNumber == winningPenguin)
        {
            Debug.Log("You guessed the winning penguin!");
        }
    }

    private void UpdateBalanceText()
    {
        balanceText.text = "Balance: $" + balance;
    }

    private void RestartGame()
    {
        gameState = GameState.NotStarted;
        isGameActive = false;
        gameStatusText.text = "Press the Start Button";
        balanceText.text = "Balance: $" + balance;
    }
    public void PenguinCollision()
    {
        // 팽귄 충돌 시 모든 팽귄 초기화 및 비활성화
        foreach (PenguinController penguin in penguins)
        {
            penguin.ResetPosition();
            penguin.DeactivatePenguin();
        }
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
}
