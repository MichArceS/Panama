using UnityEngine;
using UnityEngine.Events;

public class ZonaInteraccion : MonoBehaviour
{
    [Header("Configuración Visual")]
    [Tooltip("El objeto visual que dice 'Presiona E'")]
    public GameObject avisoVisual;

    [Header("Configuración Lógica")]
    public KeyCode teclaInteraccion = KeyCode.E;
    public string tagDelJugador = "Player";

    public UnityEvent alInteractuar;

    private bool jugadorEnRango = false;

    void Start()
    {
        if (avisoVisual != null)
            avisoVisual.SetActive(false);
    }

    void Update()
    {
        if (jugadorEnRango && Input.GetKeyDown(teclaInteraccion))
        {
            EjecutarAccion();
        }
    }

    void EjecutarAccion()
    {
        alInteractuar.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagDelJugador))
        {
            jugadorEnRango = true;
            if (avisoVisual != null)
                avisoVisual.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagDelJugador))
        {
            jugadorEnRango = false;
            if (avisoVisual != null)
                avisoVisual.SetActive(false);
        }
    }
}