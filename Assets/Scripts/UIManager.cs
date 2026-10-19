using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BoardCell[] boardsCell;

    [SerializeField] private TextMeshProUGUI statusText;

    [SerializeField] private IAManager playerO;

    void Start()
    {
        ReiniciarPartida();
    }

    // Gestión del click sobre el botón de reset
    public void OnClickReset()
    {
        ReiniciarPartida();
    }

    private void ReiniciarPartida()
    {
        // limpia el tablero(modelo)
        GameManager.StartNewGame();

        UpdateUI();
    }

    public void UpdateUI()
    {
        // actualiza el símbolo de cada celda en pantalla
        foreach (BoardCell boardCell in boardsCell)
        {
            boardCell.Refresh();
        }
        
        // actualiza el texto de estado
        if (GameManager.IsGameOver)
        {
            //poner ganador o empate
            if (GameManager.Winner == CellState.Empty)
            {
                statusText.text = "¡ Empate !";
            }
            else
            {
                statusText.text = $"¡ El ganador es: {GameManager.Winner} !";
            }
        }
        else
        {
            //informar del turno actual
            statusText.text = $"Turno actual: {GameManager.CurrentTurn}";

            if (GameManager.CurrentTurn == CellState.O)
            {
            }
        }
    }
}
