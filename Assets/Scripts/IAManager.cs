using UnityEngine;

public class IAManager : MonoBehaviour
{
    public void PonerFichaIa(CellState piece)
    {
        // recorrer el tablero (arriba->abajo, izquierda->derecha) y poner en la primera celda libre
        int i = 0;
        foreach (CellState cell in GameManager.Board)
        {
            if (cell == CellState.Empty)
            {
                if (GameManager.PlayMove(i / 3, i % 3))
                {
                    break;
                }
            }

            i++;
        }
    }
}
