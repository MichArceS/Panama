using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [Header("Prefabs de NPC")]
    public List<GameObject> npcPrefabs = new List<GameObject>();

    [Header("Configuración de spawn en secuencia")]
    public float delayEntreSpawns = 2f;
    public bool spawnAlInicio = true;

    [Header("Tag opcional para el NPC instanciado")]
    [Tooltip("Debe ser un tag que ya exista en el proyecto.")]
    public string npcTag = "";   // opcional

    private bool _spawneandoSecuencia = false;

    private void Start()
    {
        if (spawnAlInicio && npcPrefabs.Count > 0)
        {
            EmpezarSpawnSecuencia();
        }
    }

    /// <summary>
    /// Inicia la secuencia de spawns de todos los prefabs con delay.
    /// </summary>
    public void EmpezarSpawnSecuencia()
    {
        if (_spawneandoSecuencia) return;
        StartCoroutine(SecuenciaSpawn());
    }

    private IEnumerator SecuenciaSpawn()
    {
        _spawneandoSecuencia = true;

        for (int i = 0; i < npcPrefabs.Count; i++)
        {
            InstanciarNPCDesdePrefab(i);

            if (i < npcPrefabs.Count - 1 && npcPrefabs.Count > 1)
            {
                yield return new WaitForSeconds(delayEntreSpawns);
            }
        }

        _spawneandoSecuencia = false;
    }

    /// <summary>
    /// Spawnea un solo NPC (puede usarse al morir uno).
    /// Elige un prefab al azar de la lista.
    /// </summary>
    public GameObject SpawnUno()
    {
        if (npcPrefabs == null || npcPrefabs.Count == 0)
        {
            Debug.LogWarning("NPCSpawner: No hay prefabs en la lista para spawnear.");
            return null;
        }

        int indice = Random.Range(0, npcPrefabs.Count);
        return InstanciarNPCDesdePrefab(indice);
    }

    private GameObject InstanciarNPCDesdePrefab(int indice)
    {
        if (indice < 0 || indice >= npcPrefabs.Count || npcPrefabs[indice] == null)
        {
            Debug.LogWarning($"NPCSpawner: Prefab en índice {indice} es nulo o inválido.");
            return null;
        }
        Debug.Log("asdasdas");
        GameObject npc = Instantiate(npcPrefabs[indice], transform.position, transform.rotation);

        if (!string.IsNullOrEmpty(npcTag))
        {
            npc.tag = npcTag;
        }

        return npc;
    }
}
