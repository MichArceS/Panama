using Fungus;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneController : MonoBehaviour
{
    [Header("Configuración")]
    public Animator miAnimator;
    public string nombreEscena;
    public string nombreTrigger = "IsEnd";
    public float duracionAnimacion = 2f;

    private bool yaSeActivo = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !yaSeActivo)
        {
            StartCoroutine(AnimarYCambiar());
        }
    }

    IEnumerator AnimarYCambiar()
    {
        yaSeActivo = true;

        if (miAnimator != null)
        {
            miAnimator.SetBool(nombreTrigger, true);
        }

        yield return new WaitForSeconds(duracionAnimacion);

        SceneManager.LoadScene(nombreEscena);
    }

}
