using UnityEngine;
using UnityEngine.UI;

public class VisorDeImagen : MonoBehaviour
{
    public static VisorDeImagen instancia;

    [Header("Referencias UI")]
    public GameObject panelContenedor;
    public Image imagenGigante;

    [Header("Referencias Audio")]
    public AudioSource fuenteDeAudio;

    private void Awake()
    {
        instancia = this;
    }

    private void Start()
    {
        CerrarVisor();
    }

    private void Update()
    {
        if (panelContenedor.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            CerrarVisor();
        }
    }

    public void MostrarImagen(Sprite nuevaImagen, AudioClip audioExplicativo)
    {
        imagenGigante.sprite = nuevaImagen;
        imagenGigante.preserveAspect = true;
        panelContenedor.SetActive(true);

        if (audioExplicativo != null && fuenteDeAudio != null)
        {
            fuenteDeAudio.clip = audioExplicativo;
            fuenteDeAudio.Play();
        }
    }

    public void CerrarVisor()
    {
        panelContenedor.SetActive(false);

        if (fuenteDeAudio != null)
        {
            fuenteDeAudio.Stop();
            fuenteDeAudio.clip = null;
        }
    }
}