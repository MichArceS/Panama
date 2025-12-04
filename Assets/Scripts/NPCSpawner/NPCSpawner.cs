using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [Header("Prefabs de NPC")]
    [Tooltip("Arrastra aquí los prefabs de NPC que quieras spawnear en orden.")]
    public List<GameObject> npcPrefabs = new List<GameObject>();

    [Header("Configuración de spawn")]
    [Tooltip("Tiempo de espera entre un NPC y el siguiente (en segundos).")]
    public float delayEntreSpawns = 2f;

    [Tooltip("¿Spawnear automáticamente al iniciar la escena?")]
    public bool spawnAlInicio = true;

    [Header("Tag opcional para el NPC instanciado")]
    [Tooltip("Debe ser un tag que ya exista en el proyecto.")]
    public string npcTag = "";   // deja vacío si no quieres cambiar el tag

    private bool _yaSpawneo = false;

    private void Start()
    {
        if (spawnAlInicio && npcPrefabs.Count > 0)
        {
            EmpezarSpawn();
        }
    }

    /// <summary>
    /// Llama a este método para iniciar la secuencia de spawns manualmente.
    /// </summary>
    public void EmpezarSpawn()
    {
        if (_yaSpawneo) return; // opcional, por si solo quieres que pase una vez
        StartCoroutine(SecuenciaSpawn());
        _yaSpawneo = true;
    }

    private IEnumerator SecuenciaSpawn()
    {
        // Recorremos la lista de prefabs en orden
        for (int i = 0; i < npcPrefabs.Count; i++)
        {
            GameObject prefab = npcPrefabs[i];

            if (prefab == null)
            {
                Debug.LogWarning($"NPCSpawner: El prefab en el índice {i} está vacío.");
            }
            else
            {
                GameObject npc = Instantiate(prefab, transform.position, transform.rotation);

                // Si se definió un tag válido, se asigna al NPC
                if (!string.IsNullOrEmpty(npcTag))
                {
                    // IMPORTANTE: el tag debe existir en el proyecto
                    npc.tag = npcTag;
                }
            }

            // Si NO es el último, esperamos antes de spawnear el siguiente
            if (i < npcPrefabs.Count - 1 && npcPrefabs.Count > 1)
            {
                yield return new WaitForSeconds(delayEntreSpawns);
            }
        }
    }
}
