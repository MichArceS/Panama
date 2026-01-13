using UnityEngine;

public enum TipoPuntaje
{
    Restaurante,
    Fotos,
    Bar
}

public class PointsController : MonoBehaviour
{
    [Header("Contadores de Puntos")]
    public int puntosRestaurante = 0;
    public int puntosFotos = 0;
    public int puntosBar = 0;

    private void Update()
    {
        if (puntosRestaurante >= 1 && puntosFotos >= 0 && puntosBar >= 0)
        {
            Debug.Log("Completado");
        }
    }

    public void SumarPuntos(TipoPuntaje tipo, int cantidad)
    {
        switch (tipo)
        {
            case TipoPuntaje.Restaurante:
                puntosRestaurante += cantidad;
                break;

            case TipoPuntaje.Fotos:
                puntosFotos += cantidad;
                break;

            case TipoPuntaje.Bar:
                puntosBar += cantidad;
                break;
        }
    }

    public void ReiniciarPuntos()
    {
        puntosRestaurante = 0;
        puntosFotos = 0;
        puntosBar = 0;
    }
}