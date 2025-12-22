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
        Debug.Log("A213");
        if (VisorDeImagen.instancia != null)
        {
            VisorDeImagen.instancia.MostrarImagen(miImagen.sprite, audioAsociado);
        }
    }
}