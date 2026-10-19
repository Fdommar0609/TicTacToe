using UnityEngine;
public  enum CellState { Empty, X, O}

public static class GameManager
{
    //Tablero de 3x3 celdas
    public static CellState[,] Board { get; private set; } = new CellState[3, 3];
    public static CellState CurrentTurn { get; private set; } = CellState.X;
    public static bool IsGameOver { get; private set; }
    public static CellState Winner { get; private set; } = CellState.Empty;




    //Intento realizar una jugada en la posición (row, col)
    public static bool PlayMove(int row, int col)
    {
        // comprobar si el juego terminó o la casilla ya está ocupada
        if (IsGameOver || Board[row, col] != CellState.Empty)
            return false;

        // registrar la jugada
        Board[row, col] = CurrentTurn;

        // comprobar si hay algún ganador
        if (CheckWinner(row, col))
        {
            IsGameOver = true;
            Winner = CurrentTurn;
        }else if (IsBoardFull())
        {
            IsGameOver = true;
            Winner = CellState.Empty;
        }
        else
        {
            // cambiar el turno
            CurrentTurn = (CurrentTurn == CellState.X) ? CellState.O : CellState.X;
        }

        return true;
    }


    public static void StartNewGame()
    {
        Board = new CellState[3, 3];
        CurrentTurn = CellState.X;
        IsGameOver = false;
        Winner = CellState.Empty;
    }

    private static bool IsBoardFull()
    {
        // recorrer el tablero en busca de una casilla vacía (CellState.Empty)
        foreach (CellState cell in Board)
        {
            if (cell == CellState.Empty)
            {
                return false;
            }

        }

        return true;
    }

    private static bool CheckWinner(int row, int col)
    {
        // comprobar la fila en la que estoy
        if (Board[row, 0] == CurrentTurn && Board[row, 1] == CurrentTurn && Board[row, 2] == CurrentTurn)
        {
            return true;
        }

        // comprobar la columna en la que estoy
        if (Board[0, col] == CurrentTurn && Board[1, col] == CurrentTurn && Board[2, col] == CurrentTurn)
        {
            return true;
        }
        
        // comprobar la diagonal principal
        if (Board[0, 0] == CurrentTurn && Board[1, 1] == CurrentTurn && Board[2, 2] == CurrentTurn)
        {
            return true;
        }
        // comprobar la diagonal secundaria
        if (Board[0, 2] == CurrentTurn && Board[1, 1] == CurrentTurn && Board[2, 0] == CurrentTurn)
        {
            return true;
        }

        return false;
    }

}
