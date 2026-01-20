using UnityEngine;
using System.Collections;

public class RandomMusicLooper : MonoBehaviour
{
    [Header("Configuración")]
    public AudioClip[] canciones;
    public AudioSource audioSource;

    [Tooltip("Segundos de silencio entre canciones")]
    public float tiempoEntreCanciones = 2.0f;

    private int lastIndex = -1;

    void Start()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;

        StartCoroutine(DJSystem());
    }

    IEnumerator DJSystem()
    {
        while (true)
        {
            ElejirYReproducir();

            yield return new WaitForSeconds(audioSource.clip.length);

            yield return new WaitForSeconds(tiempoEntreCanciones);
        }
    }

    void ElejirYReproducir()
    {
        if (canciones.Length == 0) return;

        int index;
        if (canciones.Length == 1) index = 0;
        else
        {
            do
            {
                index = Random.Range(0, canciones.Length);
            } while (index == lastIndex);
        }

        lastIndex = index;
        audioSource.clip = canciones[index];
        audioSource.Play();
    }
}