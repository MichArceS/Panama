using UnityEngine;
using System.Collections.Generic;

public class LimitColliders : MonoBehaviour
{
    [Header("Tags que permiten la destrucción del NPC")]
    public List<string> tagsValidos = new List<string>();

    [Header("Lista de spawners a los que se notificará")]
    [Tooltip("Cuando el NPC sea destruido, se ejecutará SpawnUno() en uno o varios spawners.")]
    public List<NPCSpawner> spawners = new List<NPCSpawner>();

    [Header("Modo de spawn al activar spawners")]
    public bool spawnEnTodos = false; // Si es false → elige solo uno al azar

    private void OnCollisionEnter(Collision collision)
    {
        string tagDelOtro = collision.collider.tag;

        // ¿El tag del objeto que colisionó está en la lista?
        if (tagsValidos.Contains(tagDelOtro))
        {
            // 1. Antes de destruir, activamos los spawners
            //EjecutarSpawns();
            Destroy(collision.collider.gameObject);
        }
    }

    private void EjecutarSpawns()
    {
        if (spawners == null || spawners.Count == 0)
            return;

        if (spawnEnTodos)
        {
            // Spawnea uno desde cada spawner de la lista
            foreach (var spawner in spawners)
            {
                if (spawner != null)
                {
                    spawner.SpawnUno();
                }
            }
        }
        else
        {
            // Toma un spawner al azar y spawnea solo uno
            int indice = Random.Range(0, spawners.Count);
            NPCSpawner elegido = spawners[indice];

            if (elegido != null)
            {
                elegido.SpawnUno();
            }
        }
    }
}
