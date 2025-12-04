using UnityEngine;

public class WalkingCollider : MonoBehaviour
{
    [Header("Configuración de orientación")]
    [Tooltip("Ángulo Y al que debe girar el NPC si coincide el tag.")]
    public float nuevaOrientacionY = 90f;

    [Tooltip("Tag del NPC al que afectará este trigger.")]
    public string tagObjetivo = "NPC1";

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto entrante tiene el tag configurado
        if (other.CompareTag(tagObjetivo))
        {
            Transform npcTransform = other.transform;

            Vector3 rot = npcTransform.eulerAngles;
            rot.y = npcTransform.eulerAngles.y + nuevaOrientacionY;
            npcTransform.eulerAngles = rot;

            Debug.Log($"NPC con tag '{tagObjetivo}' girado hacia Y = {nuevaOrientacionY}");
        }
    }
}
