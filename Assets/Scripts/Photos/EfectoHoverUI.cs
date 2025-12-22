using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class EfectoHoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Configuración")]
    [Tooltip("Porcentaje de aumento. Ej: 10 hará que crezca un 10%")]
    [Range(0f, 100f)]
    public float porcentajeAumentoY = 10f;

    [Tooltip("Duración de la animación en segundos")]
    public float duracionAnimacion = 0.2f;

    private RectTransform rectTransform;
    private Vector3 escalaOriginal;
    private Vector3 escalaObjetivo;
    private Coroutine corrutinaActual;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        escalaOriginal = rectTransform.localScale;

        float factor = 1.0f + (porcentajeAumentoY / 100f);
        escalaObjetivo = escalaOriginal * factor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (corrutinaActual != null) StopCoroutine(corrutinaActual);

        corrutinaActual = StartCoroutine(AnimarEscala(escalaObjetivo));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (corrutinaActual != null) StopCoroutine(corrutinaActual);

        corrutinaActual = StartCoroutine(AnimarEscala(escalaOriginal));
    }

    IEnumerator AnimarEscala(Vector3 destino)
    {
        Vector3 inicio = rectTransform.localScale;
        float tiempoPasado = 0f;

        while (tiempoPasado < duracionAnimacion)
        {
            tiempoPasado += Time.unscaledDeltaTime;
            float porcentaje = tiempoPasado / duracionAnimacion;

            rectTransform.localScale = Vector3.Lerp(inicio, destino, porcentaje);

            yield return null;
        }

        rectTransform.localScale = destino;
    }

    void OnDisable()
    {
        if (rectTransform != null)
            rectTransform.localScale = escalaOriginal;
    }
}