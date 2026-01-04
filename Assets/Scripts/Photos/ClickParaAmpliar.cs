using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickParaAmpliar : MonoBehaviour, IPointerClickHandler
{
    [Header("Contenido")]
    public AudioClip audioAsociado;

    private Image miImagen;

    private void Start()
    {
        miImagen = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (VisorDeImagen.instancia != null)
        {
            PointsController controlador = FindFirstObjectByType<PointsController>();
            controlador.SumarPuntos(TipoPuntaje.Fotos, 1);
            VisorDeImagen.instancia.MostrarImagen(miImagen.sprite, audioAsociado);
        }
    }
}