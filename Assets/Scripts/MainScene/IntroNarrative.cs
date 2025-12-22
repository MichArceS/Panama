using UnityEngine;
using System.Collections;

public class IntroNarrative : MonoBehaviour
{
    [Header("Objetos de Texto")]
    public GameObject[] listaTextos;

    [Header("Configuración Panel Fondo")]
    public CanvasGroup panelFondo;
    public float duracionFadePanel = 2f;

    [Header("Tiempos")]
    public float tiempoLectura = 4f;
    public float duracionFadeOut = 1f;

    [Header("Animator")]
    public string nombreBoolSalida = "FadeOut";

    void Start()
    {
        if (panelFondo != null)
        {
            panelFondo.alpha = 1f;
            panelFondo.blocksRaycasts = true;
        }

        StartCoroutine(IniciarSecuencia());
    }

    IEnumerator IniciarSecuencia()
    {
        foreach (GameObject textoObj in listaTextos)
        {
            textoObj.SetActive(true);

            yield return new WaitForSeconds(tiempoLectura);

            Animator anim = textoObj.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetBool(nombreBoolSalida, true);
            }
            else
            {
                Debug.LogWarning($"El objeto {textoObj.name} no tiene Animator.");
            }

            yield return new WaitForSeconds(duracionFadeOut);

            textoObj.SetActive(false);

            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("Textos terminados. Iniciando FadeOut del fondo...");

        if (panelFondo != null)
        {
            float tiempoTranscurrido = 0f;
            float alphaInicial = panelFondo.alpha;

            while (tiempoTranscurrido < duracionFadePanel)
            {
                tiempoTranscurrido += Time.deltaTime;

                panelFondo.alpha = Mathf.Lerp(alphaInicial, 0f, tiempoTranscurrido / duracionFadePanel);

                yield return null;
            }

            panelFondo.alpha = 0f;

            panelFondo.blocksRaycasts = false;

            panelFondo.gameObject.SetActive(false); 
        }

        Debug.Log("¡Juego Iniciado!");
    }
}
