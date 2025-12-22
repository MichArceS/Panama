using UnityEngine;
using StarterAssets;

public class GestorImagen : MonoBehaviour
{
    [Header("UI a Controlar")]
    [Tooltip("El objeto que contiene la imagen (Panel o Canvas)")]
    public GameObject objetoImagen;

    [Header("Referencias del Jugador")]
    [Tooltip("Arrastra aquí a tu Player (el objeto que tiene el script StarterAssetsInputs)")]
    public StarterAssetsInputs inputJugador;

    private bool estaAbierto = false;

    void Start()
    {
        if (objetoImagen != null)
            objetoImagen.SetActive(false);
    }

    void Update()
    {
        if (estaAbierto && Input.GetKeyDown(KeyCode.Escape))
        {
            CerrarImagen();
        }
    }

    public void AbrirImagen()
    {
        if (objetoImagen != null)
        {
            objetoImagen.SetActive(true);
            estaAbierto = true;
            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (inputJugador != null)
            {
                inputJugador.cursorInputForLook = false;
                inputJugador.look = Vector2.zero;
            }
        }
    }

    public void CerrarImagen()
    {
        if (objetoImagen != null)
        {
            objetoImagen.SetActive(false);
            estaAbierto = false;
            Time.timeScale = 1f;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (inputJugador != null)
            {
                inputJugador.cursorInputForLook = true;
            }
        }
    }
}