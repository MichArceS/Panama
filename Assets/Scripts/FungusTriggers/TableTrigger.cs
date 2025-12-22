using UnityEngine;
using Fungus;

public class TableTrigger : MonoBehaviour
{
    [Header("Configuración Fungus")]
    public Flowchart targetFlowchart;
    public string blockName;

    [Header("Interacción")]
    public GameObject visualPrompt;
    public KeyCode interactionKey = KeyCode.E;

    private bool isPlayerInRange = false;

    private void Start()
    {
        if (visualPrompt != null)
        {
            visualPrompt.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(interactionKey))
        {
            if (visualPrompt != null) visualPrompt.SetActive(false);

            if (targetFlowchart != null && !string.IsNullOrEmpty(blockName))
            {
                targetFlowchart.ExecuteBlock(blockName);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;

            if (visualPrompt != null)
            {
                visualPrompt.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;

            if (visualPrompt != null)
            {
                visualPrompt.SetActive(false);
            }
        }
    }
}