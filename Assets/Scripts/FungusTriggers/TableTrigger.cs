using UnityEngine;
using Fungus;

public class TableTrigger : MonoBehaviour
{
    public Flowchart targetFlowchart;
    public string blockName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetFlowchart != null && !string.IsNullOrEmpty(blockName))
            {
                targetFlowchart.ExecuteBlock(blockName);
            }
        }
    }
}
