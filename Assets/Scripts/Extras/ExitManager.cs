using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    [Header("UI con Fade In")]
    public CanvasGroup uiCanvasGroup;
    public float duracionFadeInUI = 1.5f;

    [Header("Audio SFX")]
    public AudioSource sfxAudioSource;

    [Header("Música de Fondo (Fade Out)")]
    public List<AudioSource> audiosParaMutear;
    public float duracionFadeOutAudio = 2.0f;

    private bool eventoYaActivado = false;

    public StarterAssetsInputs inputJugador;

    public void EjecutarEvento()
    {
        if (eventoYaActivado) return;
        eventoYaActivado = true;

        inputJugador.cursorInputForLook = false;
        inputJugador.look = Vector2.zero;

        if (uiCanvasGroup != null)
        {
            StartCoroutine(FadeInUIRutina());
        }

        if (sfxAudioSource != null)
        {
            sfxAudioSource.Play();
        }

        if (audiosParaMutear.Count > 0)
        {
            StartCoroutine(FadeOutAudioRutina());
        }
    }

    IEnumerator FadeInUIRutina()
    {
        float timer = 0f;

        uiCanvasGroup.alpha = 0f;
        uiCanvasGroup.gameObject.SetActive(true);

        while (timer < duracionFadeInUI)
        {
            timer += Time.deltaTime;
            uiCanvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / duracionFadeInUI);
            yield return null;
        }

        uiCanvasGroup.alpha = 1f;

        uiCanvasGroup.interactable = true;
        uiCanvasGroup.blocksRaycasts = true;
    }

    IEnumerator FadeOutAudioRutina()
    {
        float timer = 0f;

        float[] volumenesIniciales = new float[audiosParaMutear.Count];
        for (int i = 0; i < audiosParaMutear.Count; i++)
        {
            if (audiosParaMutear[i] != null)
                volumenesIniciales[i] = audiosParaMutear[i].volume;
        }

        while (timer < duracionFadeOutAudio)
        {
            timer += Time.deltaTime;
            float porcentaje = 1 - (timer / duracionFadeOutAudio);

            for (int i = 0; i < audiosParaMutear.Count; i++)
            {
                if (audiosParaMutear[i] != null)
                    audiosParaMutear[i].volume = volumenesIniciales[i] * porcentaje;
            }
            yield return null;
        }

        foreach (var audio in audiosParaMutear)
        {
            if (audio != null) { audio.volume = 0; audio.Stop(); }
        }
    }
}