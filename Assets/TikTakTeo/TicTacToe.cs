using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TicTacToe : MonoBehaviour
{
    public Button[] gridButtons; // Drag and drop the 9 buttons from the inspector
    public TextMeshProUGUI statusText; // For displaying game status
    private string currentPlayer = "X"; // Start with player X
    private string[] board = new string[9]; // 9 spots for the board
    public GameObject WinAudio;
    public GameObject menu;

    void Start()
    {
        // Initialize the board to be empty
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = "";
            int index = i; // Capture the index for the button's click event
            gridButtons[i].onClick.AddListener(() => MakeMove(index));
        }

        UpdateStatusText();
    }

    private void Awake()
    {
        menu.SetActive(true);   
    }
    void MakeMove(int index)
    {
        // If the spot is empty and game is ongoing
        if (board[index] == "" && !IsGameOver())
        {
            board[index] = currentPlayer; // Update the board with the current player's mark
            gridButtons[index].GetComponentInChildren<TMP_Text>().text = currentPlayer; // Display it on the button

            // Check if there's a winner
            if (CheckWin())
            {
                statusText.text = "Player " + currentPlayer + " Wins!";
                StartCoroutine(Audio());
                
            }
            else if (IsBoardFull())
            {
                statusText.text = "It's a Draw!";
            }
            else
            {
                // Switch player and update the status text
                currentPlayer = (currentPlayer == "X") ? "O" : "X";
                UpdateStatusText();
            }
        }
    }

    void UpdateStatusText()
    {
        statusText.text = "Player " + currentPlayer + "'s Turn";
    }

    bool IsBoardFull()
    {
        foreach (string spot in board)
        {
            if (spot == "") return false;
        }
        return true;
    }

    bool CheckWin()
    {
        // Check all possible winning combinations
        int[,] winCombinations = new int[,]
        {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Rows
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Columns
            { 0, 4, 8 }, { 2, 4, 6 }              // Diagonals
        };

        for (int i = 0; i < winCombinations.GetLength(0); i++)
        {
            if (board[winCombinations[i, 0]] == currentPlayer &&
                board[winCombinations[i, 1]] == currentPlayer &&
                board[winCombinations[i, 2]] == currentPlayer)
            {
                return true;
            }
        }
        return false;
    }

    bool IsGameOver()
    {
        return CheckWin() || IsBoardFull();
    }

    public void ResetGame()
    {
        currentPlayer = "X";
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = "";
            gridButtons[i].GetComponentInChildren<TMP_Text>().text = "";
        }
        UpdateStatusText();
    }

    IEnumerator Audio()
    {
        WinAudio.SetActive(true);
        yield return new WaitForSeconds(3f);
        WinAudio.SetActive(false);
    }
}
