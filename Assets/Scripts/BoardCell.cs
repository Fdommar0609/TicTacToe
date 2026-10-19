using TMPro;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    [SerializeField] private int row;
    [SerializeField] private int col;
    
    [SerializeField] private TextMeshProUGUI cellText;
    [SerializeField] private UIManager uiManager;

    //Respuesta al onClick
    public void OnCLick()
    {
        Debug.Log("onClick");
        // intentar la jugada
        if (GameManager.PlayMove(row, col))
        {
            Debug.Log("Bien jugado: " + row + ", " + col);
            uiManager.UpdateUI();
            //Refresh();
        }
        else
        {
            Debug.Log("No jugada: " + row + ", " + col);
        }
    }

    public void Refresh()
    {
        CellState state = GameManager.Board[row, col];
        cellText.text = (state == CellState.Empty) ? "" : state.ToString();
    }
}
